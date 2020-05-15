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
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNumber).IsUnique();

            // Many to Many Package and item -> PackageItem
            modelBuilder.Entity<PackageItem>()
                                .HasKey(x => new { x.ItemId, x.PackageId });
            modelBuilder.Entity<PackageItem>()
                                .HasOne(p => p.Package)
                                .WithMany(i => i.PackageItems);

            modelBuilder.Entity<PackageItem>()
                                .HasOne(p => p.Item)
                                .WithMany(i => i.PackageItems);

            //Many to Many order and items -> AddOn
            modelBuilder.Entity<AddOn>()
                                .HasKey(x => new { x.ItemId, x.OrderId });
            modelBuilder.Entity<AddOn>()
                                .HasOne(o => o.Order)
                                .WithMany(i => i.AddOns);
            modelBuilder.Entity<AddOn>()
                                .HasOne(o => o.Item)
                                .WithMany(i => i.AddOns);
        }
    }
}