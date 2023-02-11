using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class ReservatieConfiguration : IEntityTypeConfiguration<Contracts.DTO.Reservation>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Reservation> builder)
        {
            //implemsenteer
            builder.ToTable("reservatie");
            builder
                .HasOne(t => t.Catering)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(t => t.Discount)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

