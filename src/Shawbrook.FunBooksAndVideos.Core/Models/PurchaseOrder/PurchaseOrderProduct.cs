using FluentValidation.Results;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder.Validators;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrderProduct : PurchaseOrderItem
{
    public int ProductId { get; init; }
    public ProductType Type { get; init; }

    public override ValidationResult Validate()
    {
        return new PurchaseOrderProductValidator().Validate(this);
    }
}
