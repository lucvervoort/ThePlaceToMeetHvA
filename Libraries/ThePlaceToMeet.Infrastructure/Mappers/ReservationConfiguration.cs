using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure.Mappers
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Contracts.DTO.Reservation>
    {
        public void Configure(EntityTypeBuilder<Contracts.DTO.Reservation> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("reservatie");

            builder.HasIndex(e => e.CateringId, "IX_Reservatie_CateringId");

            builder.HasIndex(e => e.KlantId, "IX_Reservatie_KlantId");

            builder.HasIndex(e => e.KortingId, "IX_Reservatie_KortingId");

            builder.HasIndex(e => e.VergaderruimteId, "IX_Reservatie_VergaderruimteId");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Dag).HasMaxLength(6);
            builder.Property(e => e.PrijsPerPersoonCatering).HasPrecision(18, 2);
            builder.Property(e => e.PrijsPerPersoonStandaardCatering).HasPrecision(18, 2);
            builder.Property(e => e.PrijsPerUur).HasPrecision(18, 2);

            builder.HasOne(d => d.Catering).WithMany(p => p.Reservaties)
                .HasForeignKey(d => d.CateringId)
                .HasConstraintName("FK_Reservatie_Catering_CateringId");

            builder.HasOne(d => d.Klant).WithMany(p => p.Reservaties)
                .HasForeignKey(d => d.KlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservatie_Klant_KlantId");

            builder.HasOne(d => d.Korting).WithMany(p => p.Reservaties)
                .HasForeignKey(d => d.KortingId)
                .HasConstraintName("FK_Reservatie_Korting_KortingId");

            builder.HasOne(d => d.Vergaderruimte).WithMany(p => p.Reservaties)
                .HasForeignKey(d => d.VergaderruimteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservatie_Vergaderruimte_VergaderruimteId");
        }
    }
}

