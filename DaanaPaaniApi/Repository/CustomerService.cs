using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class CustomerService : ICustomerService
    {
        protected readonly DataContext _context;
        public CustomerService(DataContext context)
        {
            _context = context;

        }
        public async Task<Customer> add(Customer customer)
        {
            var newCustomer = _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return newCustomer.Entity;
        }

        public async void delete(Customer customer)
        {
            customer.Active = false;
          
            _context.Customers.Update(customer);
            await  _context.SaveChangesAsync();
        }

        public IQueryable<Customer> getAll()
        {
           return   _context.Customers
                            .Include(c => c.Address)
                            .ThenInclude(c => c.AddressType);       
        }

        public async Task<Customer> getById(int id)
        {
            var customer = await _context.Customers
                                        .Include(c => c.Address)
                                        .ThenInclude(a => a.AddressType)
                                        .SingleOrDefaultAsync(c => c.CustomerId == id);

            return customer;
        }

        public async Task<Customer> update(int id,Customer customer)
        {
           var updatedCustomer =  _context.Update(customer);
            await _context.SaveChangesAsync();
            return updatedCustomer.Entity;
        }
    }
}
