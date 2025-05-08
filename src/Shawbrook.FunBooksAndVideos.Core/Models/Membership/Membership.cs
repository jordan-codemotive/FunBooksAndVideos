using Shawbrook.FunBooksAndVideos.Domain.Models.PurchaseOrder;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.Membership
{
    public class Membership(int id, string name, double price, MembershipType type)
    {
        public int Id => id;
        public string Name => name;
        public double Price => price;
        public MembershipType Type => type;
    }
}
