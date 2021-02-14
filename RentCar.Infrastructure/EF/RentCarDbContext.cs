using Microsoft.EntityFrameworkCore;
using RentCar.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.EF
{
    public class RentCarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        private readonly string connectionString;

        public RentCarDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // empty for now
        }
    }
}
