using Ardalis.Result;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrderMembership : PurchaseOrderItem
{
    public int MembershipId { get; init; }
    public MembershipType Type { get; init; }

    public override Result Validate()
    {
        var errors = new List<ValidationError>();

        if (MembershipId <= 0)
        {
            errors.Add(new ("Membership Id must be greater than zero."));
        }

        if (Type == MembershipType.None)
        {
            errors.Add(new ("Membership type must be specified."));
        }

        if (errors.Any())
        {
            return Result.Invalid(errors);
        }

        return Result.Success();
    }
}
