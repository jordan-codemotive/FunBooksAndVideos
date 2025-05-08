using FluentValidation;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder
{
    internal class PurchaseOrderMembershipValidator : AbstractValidator<PurchaseOrderMembership>
    {
        public PurchaseOrderMembershipValidator()
        {
            RuleFor(x => x.MembershipId)
                .GreaterThan(0)
                .WithMessage("Membership Id must be greater than zero.");

            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Membership Type is invalid.");
        }
    }
}
