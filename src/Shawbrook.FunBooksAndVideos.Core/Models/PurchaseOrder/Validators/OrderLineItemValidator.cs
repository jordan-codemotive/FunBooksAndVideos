using FluentValidation;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder.Validators;

internal class OrderLineItemValidator : AbstractValidator<OrderLineItem>
{
    public OrderLineItemValidator()
    {        
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");  
    }
}