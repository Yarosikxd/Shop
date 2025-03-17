using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public partial class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItemEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseItemEntity> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.Quantity)
                .IsRequired();

            builder.HasOne(pi => pi.Purchase)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(pi => pi.PurchaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.PurchaseItems)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
