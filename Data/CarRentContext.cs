using Microsoft.EntityFrameworkCore;
using System;
using Data.Models;

namespace Data
{
    public class CarRentContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Driver> Drivers { get; set; } 
        public DbSet<Payment> Payments { get; set; }
        public CarRentContext(DbContextOptions<CarRentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
    }
}
