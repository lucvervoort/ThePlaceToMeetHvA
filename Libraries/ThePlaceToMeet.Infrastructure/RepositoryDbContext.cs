using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThePlaceToMeet.Contracts.DTO;
using ThePlaceToMeet.Infrastructure.Mappers;
//using ThePlaceToMeet.Infrastructure.Mappers;

namespace ThePlaceToMeet.Infrastructure
{
    public class RepositoryDbContext : IdentityDbContext<ThePlaceToMeet.Infrastructure.DTO.ApplicationUser>
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CateringConfiguration());
            builder.ApplyConfiguration(new KlantConfiguration());
            builder.ApplyConfiguration(new KortingConfiguration());
            builder.ApplyConfiguration(new ReservatieConfiguration());
            builder.ApplyConfiguration(new VergaderruimteConfiguration());
        }
        */

        public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

        public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }

        public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

        public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }

        public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }

        public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }

        public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }

        public virtual DbSet<Catering> Caterings { get; set; }

        public virtual DbSet<Customer> Klanten { get; set; }

        public virtual DbSet<Discount> Kortingen { get; set; }

        public virtual DbSet<Reservation> Reservaties { get; set; }

        public virtual DbSet<MeetingRoom> Vergaderruimtes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //    => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=ZwarteRidder007;database=theplacetomeet", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

                entity.Property(e => e.Id).HasMaxLength(450);
                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(0);
                entity.Property(e => e.Name).HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.ClaimType).HasMaxLength(0);
                entity.Property(e => e.ClaimValue).HasMaxLength(0);
                entity.Property(e => e.RoleId).HasMaxLength(450);
            });

            modelBuilder.Entity<Aspnetuser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex").HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

                entity.Property(e => e.Id).HasMaxLength(450);
                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(0);
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.LockoutEnd).HasMaxLength(6);
                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
                entity.Property(e => e.PasswordHash).HasMaxLength(0);
                entity.Property(e => e.PhoneNumber).HasMaxLength(0);
                entity.Property(e => e.SecurityStamp).HasMaxLength(0);
                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.ClaimType).HasMaxLength(0);
                entity.Property(e => e.ClaimValue).HasMaxLength(0);
                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);
                entity.Property(e => e.ProviderKey).HasMaxLength(128);
                entity.Property(e => e.ProviderDisplayName).HasMaxLength(0);
                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Aspnetuserrole>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.RoleId).HasMaxLength(450);
                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasMaxLength(450);
                entity.Property(e => e.LoginProvider).HasMaxLength(128);
                entity.Property(e => e.Name).HasMaxLength(128);
                entity.Property(e => e.Value).HasMaxLength(0);
            });

            modelBuilder.ApplyConfiguration(new CateringConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingRoomConfiguration());
        }
    }
}
