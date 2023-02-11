using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class KortingConfiguration : IEntityTypeConfiguration<Contracts.DTO.Discount>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Discount> builder)
        {
            builder.ToTable("korting");
            builder.Property(t => t.MinimumReservationsInAYear).HasColumnName("MinimumAantalReservatiesInJaar");
        }
    }
}

