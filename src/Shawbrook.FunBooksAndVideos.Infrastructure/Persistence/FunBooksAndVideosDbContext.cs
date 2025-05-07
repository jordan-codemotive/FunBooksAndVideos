using Microsoft.EntityFrameworkCore;
using Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Entities;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence
{
    internal class FunBooksAndVideosDbContext : DbContext
    {
        public FunBooksAndVideosDbContext(DbContextOptions<FunBooksAndVideosDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<PurchaseOrderEntity> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLineItemEntity> PurchaseOrderLineItems { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<MembershipEntity> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurchaseOrderEntity>()
                .HasMany(po => po.Items)
                .WithOne(li => li.PurchaseOrder)
                .HasForeignKey(li => li.PurchaseOrderId);
        }
    }
}
