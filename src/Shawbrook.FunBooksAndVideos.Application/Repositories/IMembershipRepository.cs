using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Domain.Models.Membership;

namespace Shawbrook.FunBooksAndVideos.Application.Repositories
{
    public interface IMembershipRepository
    {
        public Result<Membership> Get(int id);
    }
}