using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;
using Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Entities;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Repositories;

internal class PurchaseOrderRepository(FunBooksAndVideosDbContext dbContext) : IPurchaseOrderRepository
{
    public async Task<Result<PurchaseOrder>> Get(int purchaseOrderId)
    {
        var entity = await dbContext.PurchaseOrders.SingleOrDefaultAsync(x => x.Id == purchaseOrderId);

        if (entity is null)
        {
            return Result.NotFound();
        }

        var purchaseOrder = PurchaseOrder.CreateExisting(
            customerId: entity.CustomerId,
            id: entity.Id);

        foreach (var item in entity.Items)
        {
            purchaseOrder.AddLineItem(new OrderLineItem
            {
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity,
                PurchaseOrderId = item.PurchaseOrderId,
                MembershipType = (MembershipType?)item.MembershipType,
                ProductId = item.ProductId,
            });
        } 
        
        return purchaseOrder;
    }

    public async Task<Result<int>> Save(PurchaseOrder purchaseOrder)
    {
        // TODO: Create mapper.
        var items = purchaseOrder.OrderLines.Select(x => new PurchaseOrderLineItemEntity 
        { 
            Quantity = x.Quantity, 
            Price = x.Price, 
            PurchaseOrderId = x.PurchaseOrderId,
            MembershipType = (byte?) x.MembershipType,
            ProductId = x.ProductId
        }).ToList();
        
        var purchaseOrderEntity = new PurchaseOrderEntity
        {
            CustomerId = purchaseOrder.CustomerId,
            Items = items
        };

        dbContext.PurchaseOrders.Add(purchaseOrderEntity);
        await dbContext.SaveChangesAsync();

        return purchaseOrderEntity.Id;
    }
}