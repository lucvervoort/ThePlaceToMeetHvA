using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class VergaderruimteConfiguration : IEntityTypeConfiguration<Contracts.DTO.MeetingRoom>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.MeetingRoom> builder)
        {
            builder.ToTable("Vergaderruimte");
            builder.HasMany(t => t.Reservaties).WithOne(t => t.MeetingRoom).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
