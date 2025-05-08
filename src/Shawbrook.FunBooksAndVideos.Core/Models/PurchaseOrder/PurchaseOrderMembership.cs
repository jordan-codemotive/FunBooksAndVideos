using FluentValidation.Results;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrderMembership : PurchaseOrderItem
{
    public int MembershipId { get; init; }
    public MembershipType Type { get; init; }

    public override ValidationResult Validate()
    {
        return new PurchaseOrderMembershipValidator().Validate(this);
    }
}
