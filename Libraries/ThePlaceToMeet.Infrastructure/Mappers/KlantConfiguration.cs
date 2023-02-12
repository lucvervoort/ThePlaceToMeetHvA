using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class KlantConfiguration : IEntityTypeConfiguration<Contracts.DTO.Customer>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Customer> builder)
        {
            builder.ToTable("klant");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.LastName).HasColumnName("Naam").IsRequired().HasMaxLength(100);
            builder.Property(t => t.FirstName).HasColumnName("Voornaam").IsRequired().HasMaxLength(100);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Mobile).HasColumnName("GSM");
            builder.Property(t => t.Company).HasColumnName("Bedrijf");

            builder.HasMany(t => t.Reservations).WithOne().IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

