using System.ComponentModel.DataAnnotations;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Entities
{
    internal class PurchaseOrderEntity
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public List<PurchaseOrderLineItemEntity> Items { get; set; } = [];
    }
}
