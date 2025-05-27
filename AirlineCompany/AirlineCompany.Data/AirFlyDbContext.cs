using AirlineCompany.Data.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AirlineCompany.Models;
using Microsoft.AspNetCore.Identity;

namespace AirlineCompany.Data
{
    public class AirFlyDbContext : IdentityDbContext
    {
        public AirFlyDbContext(DbContextOptions<AirFlyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; } = null!;
        public DbSet<Plane> Planes { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<TicketType> TicketTypes { get; set; } = null!;
        public DbSet<LuggageType> LuggageTypes { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<ActivityLog> ActivityLogs { get; set; } = null!;
        public DbSet<FlightSeatAvailability> FlightSeatAvailabilities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("21180083");

            modelBuilder.Entity<IdentityUser>(b => { b.ToTable("AspNetUsers"); });
            modelBuilder.Entity<IdentityRole>(b => { b.ToTable("AspNetRoles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(b => { b.ToTable("AspNetUserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("AspNetUserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("AspNetUserLogins"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("AspNetRoleClaims"); });
            modelBuilder.Entity<IdentityUserToken<string>>(b => { b.ToTable("AspNetUserTokens"); });

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureDestination)
                .WithMany(d => d.Departures)
                .HasForeignKey(f => f.DepartureDestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ArrivalDestination)
                .WithMany(d => d.Arrivals)
                .HasForeignKey(f => f.ArrivalDestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Flight)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FlightId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Status)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.StatusId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TicketType)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TicketId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.LuggageType)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.LuggageId);

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.Reservation)
                .WithMany(r => r.Passengers)
                .HasForeignKey(p => p.ReservationId);

            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Flight)
                .WithMany(f => f.Seats)
                .HasForeignKey(s => s.FlightId);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.SeatAvailability)
                .WithOne(s => s.Flight)
                .HasForeignKey<FlightSeatAvailability>(s => s.FlightId);

            modelBuilder.ApplyHasTrigger();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.LastModifiedOn = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedOn = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}