using Ardalis.Result;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Domain.Models.Product;
using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly IList<Product> _products = [];

    public ProductRepository()
    {
        _products.Add(new Product(id: 1, name: "The Girl on the train", price: 10.99, type: ProductType.Book));
        _products.Add(new Product(id: 2, name: "Comprehensive First Aid Training", price: 5.99, type: ProductType.Video));
    }

    public Result<Product> Get(int productId)
    {
        // I didn't have time to create the table and seed with a catalog of data.
        var result = _products.SingleOrDefault(x => x.Id == productId);
        
        if (result is null)
        {
            return Result.NotFound();
        }

        return Result.Success(result);
    }
}