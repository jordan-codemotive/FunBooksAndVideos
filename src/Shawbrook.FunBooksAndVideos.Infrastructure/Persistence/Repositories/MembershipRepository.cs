using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Domain.Models.Membership;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Repositories
{
    internal class MembershipRepository : IMembershipRepository
    {
        private readonly IList<Membership> _membership = [];

        public MembershipRepository()
        {
            _membership.Add(new Membership(id: 1, name: "Book Club", price: 5.99, type: MembershipType.BookClub));
            _membership.Add(new Membership(id: 2, name: "Video Club", price: 10.99, type: MembershipType.VideoClub));
            _membership.Add(new Membership(id: 3, name: "Premium Club", price: 12.99, type: MembershipType.PremiumClub));
        }

        public Result<Membership> Get(int productId)
        {
            // I didn't have time to create the table and seed with a catalog of data.
            var result = _membership.SingleOrDefault(x => x.Id == productId);

            if (result is null)
            {
                return Result<Membership>.NotFound();
            }

            return Result.Success(result);
        }
    }
}