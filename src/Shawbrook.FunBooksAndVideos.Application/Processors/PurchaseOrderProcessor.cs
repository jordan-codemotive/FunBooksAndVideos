using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Models;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Application.Services;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;
using Shawbrook.FunBooksAndVideos.WebApi.Models.Requests;

namespace Shawbrook.FunBooksAndVideos.Application.Processors;

internal class PurchaseOrderProcessor(
    ICustomerRepository customerRepository,
    IProductRepository productRepository,
    IPurchaseOrderRepository purchaseOrderRepository,
    IMembershipRepository membershipRepository,
    IShippingService shippingService)
    : IPurchaseOrderProcessor
{
    public async Task<Result> Process(PurchaseOrderRequest request)
    {
        var customerExists = customerRepository.CheckCustomerExists(request.CustomerId);

        if (customerExists is false)
        {
            return Result.NotFound($"Customer with id {request.CustomerId} not found.");
        }

        var purchaseOrder = PurchaseOrder.CreateNew(request.CustomerId);

        if (request.Membership is not null)
        {
            var membership = membershipRepository.Get(request.Membership.Id);
            if (membership.IsNotFound())
            {
                // TODO: Add logging & Improve by collecting all errors and returning them at once.
                return Result.NotFound($"Product with id {request.Membership.Id} not found.");
            }

            purchaseOrder.AddLineItem(new OrderLineItem
            {                
                MembershipType = membership.Value.Type,
                Price = membership.Value.Price,
                PurchaseOrderId = purchaseOrder.Id,
                Quantity = 1
            });

            customerRepository.ActivateCustomer(request.CustomerId, request.Membership.Id);
        }

        foreach (var productLineItem in request.Products ?? Enumerable.Empty<PurchaseOrderProductDto>())
        {
            var product = productRepository.Get(productLineItem.Id);

            if (product.IsNotFound())
            {
                // TODO: Add logging & Improve by collecting all errors and returning them at once.
                return Result.NotFound($"Product with id {productLineItem.Id} not found.");
            }

            purchaseOrder.AddLineItem(new OrderLineItem
            {
                ProductType = product.Value.Type,
                Price = product.Value.Price,
                PurchaseOrderId = purchaseOrder.Id,
                Quantity = productLineItem.Quantity
            });
        }

        // TODO: implement transaction control - so if any operation fails all of them are rolled back.
        var saveResult = await purchaseOrderRepository.Save(purchaseOrder);

        if (!saveResult.IsSuccess)
        {
            return Result.Error("Failed to save purchase order.");
        }
        else if (purchaseOrder.ContainsPhysicalProduct())
        {
            shippingService.GenerateShippingSlip(purchaseOrder);
        }

        return Result.Success();
    }
}
