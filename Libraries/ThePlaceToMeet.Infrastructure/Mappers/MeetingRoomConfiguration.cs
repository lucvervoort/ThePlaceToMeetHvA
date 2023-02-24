using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class MeetingRoomConfiguration : IEntityTypeConfiguration<Contracts.DTO.MeetingRoom>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.MeetingRoom> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("vergaderruimte");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Naam).HasMaxLength(4096);
            builder.Property(e => e.PrijsPerPersoonStandaardCatering).HasPrecision(18, 2);
            builder.Property(e => e.PrijsPerUur).HasPrecision(18, 2);
        }
    }
}
