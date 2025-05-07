using Shawbrook.FunBooksAndVideos.Application.Models;

namespace Shawbrook.FunBooksAndVideos.WebApi.Models.Requests
{
    public record PurchaseOrderRequest(     
        int CustomerId, // TODO: Get from JWT token
        IReadOnlyList<PurchaseOrderProductDto> Products,
        IReadOnlyList<PurchaseOrderMembershipDto> Memberships);
}
