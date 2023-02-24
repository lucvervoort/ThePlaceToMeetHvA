using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class CateringConfiguration : IEntityTypeConfiguration<Contracts.DTO.Catering>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Catering> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("catering");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Beschrijving).HasMaxLength(2048);
            builder.Property(e => e.PrijsPerPersoon).HasPrecision(18, 2);
            builder.Property(e => e.Titel).HasMaxLength(100);
        }
    }
}

