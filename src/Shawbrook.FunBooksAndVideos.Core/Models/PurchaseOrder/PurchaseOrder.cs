using Ardalis.Result;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrder
{
    private PurchaseOrder(int customerId)
    {
        CustomerId = customerId;
    }

    public int Id { get; private set; }
    public int CustomerId { get; init; }
    public IList<PurchaseOrderItem> OrderLines { get; } = [];
    public decimal TotalPrice => OrderLines.Sum(i => i.Price);
    public bool ContainsMembership() =>
       OrderLines.Any(line => line is PurchaseOrderMembership);
    public bool ContainsPhysicalProduct() =>
        OrderLines.Any(line => line is PurchaseOrderProduct);

    public static PurchaseOrder CreateNew(int customerId)
    {
        return new PurchaseOrder(customerId);
    }

    public static PurchaseOrder CreateExisting(int id, int customerId)
    {
        return new PurchaseOrder(customerId) { Id = id };
    }

    public void AddLineItem(PurchaseOrderItem item)
    {      
        var validateResult = item.Validate();
        
        if (!validateResult.IsValid)
        {
            // TODO: Log a warning.
            return;
        }           

        OrderLines.Add(item);
    }
}
