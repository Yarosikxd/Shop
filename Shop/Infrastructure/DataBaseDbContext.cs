using Infrastructure.Configurations;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options) : base(options) { }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<PurchaseItemEntity> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseItemConfiguration());
        }
    }
}
