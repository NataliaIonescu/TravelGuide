using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TravelGuide.Models
{
    public class TravelContext : IdentityDbContext<AppUser>
    {
        public TravelContext(DbContextOptions<TravelContext> options)
:           base(options)
        { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityTour> CityTours { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Booking>()
            //.HasOne(e => e.AppUser)
            //.WithMany(e => e!.Bookings)
            //.HasForeignKey(e => e.AppUserID)
            //.IsRequired();

            modelBuilder.Entity<Booking>()
            .HasOne(e => e.Offer)
            .WithMany(e => e.Bookings)
            .HasForeignKey(e => e.OfferID)
            .IsRequired();

            modelBuilder.Entity<City>()
            .HasMany(m => m.CityTours)
            .WithOne(e => e.City)
            .IsRequired();

            modelBuilder.Entity<Hotel>()
            .HasMany(m => m.Offers)
            .WithOne(e => e.Hotel)
            .IsRequired();

            modelBuilder.Entity<CityTour>()
           .HasMany(m => m.Offers)
           .WithOne(e => e.CityTour)
           .IsRequired();

            base.OnModelCreating(modelBuilder);
        }   
    }
}
