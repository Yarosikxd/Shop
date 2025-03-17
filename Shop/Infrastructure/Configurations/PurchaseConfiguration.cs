using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public partial class PurchaseConfiguration : IEntityTypeConfiguration<PurchaseEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Client)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
