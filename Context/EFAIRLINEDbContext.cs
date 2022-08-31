using EFAirLine.Entities;
using EFAIRLINE.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFAIRLINE.Context
{
    public class EFAIRLINEDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;database=EFAIRLINE;port=3306;password=@nooruraheem02");
        }
        public DbSet<User> Users{get;set;}
        public DbSet<Passenger> Passengers{get;set;}
        public DbSet<Booking> Bookings{get;set;}
        public DbSet<Address> Addresses{get;set;}
        public DbSet<Payment> Payments{get;set;}
        public DbSet<Flight> Flights{get;set;}
        public DbSet<AirCraft> AirCrafts{get;set;}
    }
}