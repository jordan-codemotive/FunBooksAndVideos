namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrderProduct : PurchaseOrderItem
{
    public int ProductId { get; init; }
    public ProductType Type { get; init; }
}
