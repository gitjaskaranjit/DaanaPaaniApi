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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ItemItem> ItemItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNumber).IsUnique();

       

            modelBuilder.Entity<OrderItem>()
                                .HasOne(p => p.Order)
                                .WithMany(i => i.OrderItems)
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                                .HasOne(p => p.Item)
                                .WithMany(i => i.OrderItems)
                                .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<ItemItem>().HasKey(i=> new {i.ParentItemId ,i.ChildItemId });
            modelBuilder.Entity<Item>().HasMany(i => i.childItems)
                                        .WithOne(i => i.ParentItem).
                                        HasForeignKey(i => i.ParentItemId);

            modelBuilder.Entity<Item>().HasMany(i => i.ParentItems)
                                        .WithOne(i => i.ChildItem)
                                        .HasForeignKey(i => i.ChildItemId)
                                        .OnDelete(DeleteBehavior.Restrict);



            //locationInfo cooridates
            modelBuilder.Entity<Location>().Property(c => c.LocationPoints)
                 .HasSrid(4326);
        }
    }
}