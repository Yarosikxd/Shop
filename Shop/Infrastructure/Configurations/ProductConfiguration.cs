using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public partial class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Article)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
