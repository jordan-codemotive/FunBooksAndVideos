using Ardalis.Result;
using Microsoft.Extensions.Logging;
using Shawbrook.FunBooksAndVideos.Application.Services;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Messaging
{
    public class ShippingService(ILogger<ShippingService> logger) : IShippingService
    {
        public Result GenerateShippingSlip(PurchaseOrder purchaseOrder)
        {
            logger.LogInformation("Generating Shipping slip for purchaseOrder {id}", purchaseOrder.Id);

            return Result.Success();
        }
    }
}
