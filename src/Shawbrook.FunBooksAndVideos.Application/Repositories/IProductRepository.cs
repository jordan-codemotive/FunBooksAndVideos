using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Domain.Models.Product;

namespace Shawbrook.FunBooksAndVideos.Application.Repositories
{
    public interface IProductRepository
    {
        public Result<Product> Get(int productId);
    }
}