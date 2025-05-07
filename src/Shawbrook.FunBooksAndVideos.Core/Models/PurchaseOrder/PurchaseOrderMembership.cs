namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrderMembership : PurchaseOrderItem
{
    public int MembershipId { get; init; }
    public MembershipType Type { get; init; }
}
