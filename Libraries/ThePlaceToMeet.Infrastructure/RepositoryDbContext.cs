using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Infrastructure.Mappers;

namespace ThePlaceToMeet.Infrastructure
{
    public class RepositoryDbContext : IdentityDbContext<ThePlaceToMeet.Infrastructure.DTO.ApplicationUser>
    {
        public DbSet<Contracts.DTO.Catering> Caterings { get; set; }
        public DbSet<Contracts.DTO.Customer> Klanten { get; set; }
        public DbSet<Contracts.DTO.MeetingRoom> Vergaderruimtes { get; set; }
        public DbSet<Contracts.DTO.Discount> Kortingen { get; set; }

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CateringConfiguration());
            builder.ApplyConfiguration(new KlantConfiguration());
            builder.ApplyConfiguration(new KortingConfiguration());
            builder.ApplyConfiguration(new ReservatieConfiguration());
            builder.ApplyConfiguration(new VergaderruimteConfiguration());
        }
    }
}
