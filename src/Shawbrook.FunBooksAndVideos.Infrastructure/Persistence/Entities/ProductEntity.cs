using System.ComponentModel.DataAnnotations;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Entities
{
    internal class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
    }
}
