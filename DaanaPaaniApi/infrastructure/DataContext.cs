using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DaanaPaaniApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverAddress> DriverAddresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderTemplete> OrderTempletes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNumber).IsUnique();

            // Many to Many Package and item -> PackageItem
            modelBuilder.Entity<OrderItem>()
                                .HasOne(p => p.Order)
                                .WithMany(i => i.OrderItems);

            modelBuilder.Entity<OrderItem>()
                                .HasOne(p => p.Item)
                                .WithMany(i => i.OrderItems);

        
            //locationInfo cooridates
            modelBuilder.Entity<Location>().Property(c => c.LocationPoints)
                 .HasSrid(4326);
        }
    }
}