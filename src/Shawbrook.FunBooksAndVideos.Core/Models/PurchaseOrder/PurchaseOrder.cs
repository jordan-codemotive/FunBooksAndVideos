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
    public IList<PurchaseOrderItem> Items { get; } = [];
    public decimal TotalPrice => Items.Sum(i => i.Price);

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
        
        if (validateResult.IsInvalid())
        {
            // TODO: Log a warning.
            return;
        }           

        Items.Add(item);
    }
}
