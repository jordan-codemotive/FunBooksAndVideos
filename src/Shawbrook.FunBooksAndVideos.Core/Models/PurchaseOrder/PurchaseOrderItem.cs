namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public abstract class PurchaseOrderItem()
{
    public int PurchaseOrderItemId { get; init; }
    public int PurchaseOrderId { get; init; }
    public int Quantity { get; init; }    
    public decimal Price { get; init; }
    //public abstract bool Validate();
}
