using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Services;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Messaging
{
    public class ShippingService : IShippingService
    {
        public Result GenerateShippingSlip(PurchaseOrder purchaseOrder)
        {
            return Result.Success();
        }
    }
}
