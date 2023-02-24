using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Contracts.DTO.Customer>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Customer> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("klant");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Bedrijf).HasMaxLength(4096);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Gsm)
                .HasMaxLength(4096)
                .HasColumnName("GSM");
            builder.Property(e => e.Naam).HasMaxLength(100);
            builder.Property(e => e.Voornaam).HasMaxLength(100);
        }
    }
}

 