using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Application.Repositories;

public interface IPurchaseOrderRepository
{
    public Task<Result<PurchaseOrder>> Get(int purchaseOrderId);
    public Task<int> Save(PurchaseOrder purchaseOrder);
}
