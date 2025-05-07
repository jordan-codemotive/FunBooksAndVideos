using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;
using Shawbrook.FunBooksAndVideos.WebApi.Models.Requests;

namespace Shawbrook.FunBooksAndVideos.Application.Processors;

public interface IPurchaseOrderProcessor
{
    public Task<Result> Process(PurchaseOrderRequest request);
}

internal class PurchaseOrderProcessor(
    IProductRepository productRepository,
    IPurchaseOrderRepository purchaseOrderRepository)
    : IPurchaseOrderProcessor
{
    public async Task<Result> Process(PurchaseOrderRequest request)
    {
        var purchaseOrder = new PurchaseOrder(1, request.CustomerId);

        foreach (var productLineItem in request.Products)
        {
            var product = productRepository.Get(productLineItem.Id);

            if (product.IsNotFound())
            {
                // TODO: Add logging
                // TODO: Improve by collecting all errors and returning them at once.
                return Result.NotFound($"Product with id {productLineItem.Id} not found.");
            }
            purchaseOrder.AddLineItem(new PurchaseOrderProduct
            {
                ProductId = productLineItem.Id,
                Quantity = productLineItem.Quantity,
                Type = product.Value.Type
            });
        }

        foreach (var membership in request.Memberships)
        {
            purchaseOrder.AddLineItem(new PurchaseOrderMembership
            {
                MembershipId = membership.Id,
            });
        }

        await purchaseOrderRepository.Add(purchaseOrder);

        return Result.Success();
    }
}
