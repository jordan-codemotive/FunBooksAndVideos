using FluentValidation;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder.Validators;

internal class PurchaseOrderProductValidator : AbstractValidator<PurchaseOrderProduct>
{
    public PurchaseOrderProductValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Product Id must be greater than zero.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");
    }
}