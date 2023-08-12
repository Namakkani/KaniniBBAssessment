using Microsoft.EntityFrameworkCore;
using Tourismandtravel.Models;


namespace Tourismandtravel.Data
{
    public class TourismdbContext : DbContext
    {
        public TourismdbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Room> Room { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        
            
    }
}
