using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class RentCarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RentCarDbContext(DbContextOptions<RentCarDbContext> options) : base(options) 
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // empty for now
        }
    }
}
