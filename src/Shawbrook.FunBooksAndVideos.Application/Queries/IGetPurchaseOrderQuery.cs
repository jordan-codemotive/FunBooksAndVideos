using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Models.Responses;

namespace Shawbrook.FunBooksAndVideos.Application.Queries;

public interface IGetPurchaseOrderQuery
{
    public Task<Result<PurchaseOrderResponse>> Get(int purchaseOrderId);
}
