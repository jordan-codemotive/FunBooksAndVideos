using FluentValidation;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder.Validators;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

public class OrderLineItem
{
    public int Id { get; init; }
    public required int PurchaseOrderId { get; init; }
    public required int Quantity { get; init; }
    public required double Price { get; init; }
    public int? ProductId { get; init; }
    public MembershipType? MembershipType { get; set; }
    public ProductType ProductType { get; set; }

    public void Validate()
    {
        new OrderLineItemValidator().ValidateAndThrow(this);
    }
}
