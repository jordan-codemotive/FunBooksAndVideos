using System.ComponentModel.DataAnnotations;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Entities
{
    internal class MembershipEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required byte Type { get; set; }
    }
}
