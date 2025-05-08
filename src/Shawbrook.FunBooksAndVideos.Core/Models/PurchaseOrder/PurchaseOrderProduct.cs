using Ardalis.Result;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class PurchaseOrderProduct : PurchaseOrderItem
{
    public int ProductId { get; init; }
    public ProductType Type { get; init; }

    public override Result Validate()
    {
        var errors = new List<ValidationError>();

        if (ProductId <= 0)
        {
            errors.Add(new("Product Id must be greater than zero."));
        }

        if (Type == ProductType.None)
        {
            errors.Add(new("Product type must be specified."));
        }

        if (errors.Any())
        {
            return Result.Invalid(errors);
        }

        return Result.Success();
    }
}
