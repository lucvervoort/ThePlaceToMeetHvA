using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class CateringConfiguration : IEntityTypeConfiguration<Contracts.DTO.Catering>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Catering> builder)
        {
            builder.ToTable("catering");
            builder.Property(t => t.Titel).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Beschrijving).IsRequired();
        }
    }
}

