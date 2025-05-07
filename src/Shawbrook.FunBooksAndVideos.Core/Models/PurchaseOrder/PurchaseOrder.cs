namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrder(
    int id,
    int customerId)
{
    public int Id => id;
    public int CustomerId => customerId;
    public IList<PurchaseOrderItem> Items { get; } = [];
    public decimal TotalPrice => Items.Sum(i => i.Price);

    public void AddLineItem(PurchaseOrderItem item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        // TODO: Validate line item

        Items.Add(item);
    }
}
