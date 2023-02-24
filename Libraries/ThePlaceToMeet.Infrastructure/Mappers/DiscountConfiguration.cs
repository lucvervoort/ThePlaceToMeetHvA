using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Contracts.DTO.Discount>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Discount> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("korting");

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}

