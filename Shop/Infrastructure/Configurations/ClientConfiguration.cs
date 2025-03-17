using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public partial class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.BirthDate)
                .IsRequired();

            builder.Property(c => c.RegistrationDate)
                .IsRequired();

            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
