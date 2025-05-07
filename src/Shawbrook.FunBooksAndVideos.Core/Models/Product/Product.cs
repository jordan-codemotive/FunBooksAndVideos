using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.Product
{
    public class Product(int id, string name, double price, ProductType type)
    {
        public int Id => id;        
        public string Name => name;
        public double Price => price;
        public ProductType Type => type;
    }
}
