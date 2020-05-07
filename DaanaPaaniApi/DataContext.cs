
using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<Address> Addresses { get; set; }
       public DbSet<AddressType> AddressTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired();
            modelBuilder.Entity<Customer>().HasIndex(c => c.PhoneNumber).IsUnique() ;
        }
    }
    
}
