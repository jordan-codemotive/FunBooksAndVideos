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

        return PurchaseOrder.CreateExisting(
            customerId: entity.CustomerId,
            id: entity.Id);
           
    }

    public async Task<Result<int>> Save(PurchaseOrder purchaseOrder)
    {
        // TODO: Create mapper.
        var items = purchaseOrder.OrderLines.Select(x => new PurchaseOrderLineItemEntity() { Quantity = x.Quantity }).ToList();
        var purchaseOrderEntity = new PurchaseOrderEntity
        {
            CustomerId = purchaseOrder.CustomerId,
            Items = items
        };

        dbContext.PurchaseOrders.Add(purchaseOrderEntity);
        await dbContext.SaveChangesAsync();

        return purchaseOrder.Id;
    }
}