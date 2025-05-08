using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Models.Responses;
using Shawbrook.FunBooksAndVideos.Application.Repositories;

namespace Shawbrook.FunBooksAndVideos.Application.Queries;

internal class GetPurchaseOrderQuery(IPurchaseOrderRepository repository) : IGetPurchaseOrderQuery
{
    public async Task<Result<PurchaseOrderResponse>> Get(int purchaseOrderId)
    {
        var purchaseOrderResult = await repository.Get(purchaseOrderId);

        if (purchaseOrderResult.IsNotFound())
        {
            return Result.NotFound();
        }

        return new PurchaseOrderResponse(
             Id: purchaseOrderResult.Value.Id,
             CustomerId: purchaseOrderResult.Value.CustomerId);
    }
}
