using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Application.Services;

public interface IShippingService
{
    public Result GenerateShippingSlip(PurchaseOrder purchaseOrder);    
}
