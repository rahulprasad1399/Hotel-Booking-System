using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Data
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=HotelApp;User Id=sa;Password=Rahul@123;TrustServerCertificate=True;");
        }

        public DbSet<Booking> bookings { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }

    }
}
