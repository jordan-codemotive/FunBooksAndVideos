namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrder
{
    private PurchaseOrder(int customerId)
    {
        CustomerId = customerId;
    }

    public int Id { get; private set; }
    public int CustomerId { get; init; }
    public IList<OrderLineItem> OrderLines { get; } = [];
    public double TotalPrice => OrderLines.Sum(i => i.Price);
    public bool ContainsMembership() =>
       OrderLines.Any(line => line.ProductType == ProductType.Membership);
    public bool ContainsPhysicalProduct() =>
        OrderLines.Any(line => new List<ProductType> { ProductType.Video, ProductType.Book }.Contains(line.ProductType));

    public static PurchaseOrder CreateNew(int customerId)
    {
        return new PurchaseOrder(customerId);
    }

    public static PurchaseOrder CreateExisting(int id, int customerId)
    {
        return new PurchaseOrder(customerId) { Id = id };
    }

    public void AddLineItem(OrderLineItem item)
    {
        item.Validate();        

        OrderLines.Add(item);
    }
}
