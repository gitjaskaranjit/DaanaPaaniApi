using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Model;
using Microsoft.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class CustomerService : ICustomerService
    {
        protected readonly DataContext _context;
        private readonly IGoogleGeocode _googleGeocode;

        public CustomerService(DataContext context,
            IGoogleGeocode googleGeocode
            )
        {
            _context = context;
            _googleGeocode = googleGeocode;
        }

        public async Task<Customer> add(Customer customer)
        {
            var locationInfo = await _googleGeocode.GetLocationInfoAsync(customer.Address);
            if (!_googleGeocode.error)
            {
                var newCustomer = _context.Customers.Update(customer);

                var location = new LocationInfo
                {
                    lat = locationInfo.Results[0].Geometry.location.lat,
                    lng = locationInfo.Results[0].Geometry.location.lng,
                    placeId = locationInfo.Results[0].PlaceId,
                    formatted_address = locationInfo.Results[0].FormattedAddress,
                    customer = newCustomer.Entity
                };
                _context.LocationInfos.Update(location);
                await _context.SaveChangesAsync();
                return newCustomer.Entity;
            }
            else
            {
                throw new InvalidOperationException("Problem occured check your address");
            }
        }

        public async void delete(Customer customer)
        {
            customer.Active = false;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Customer> getAll()
        {
            var customers = _context.Customers
                              .Include(c => c.Address)
                              .ThenInclude(c => c.AddressType);

            return customers;
        }

        public async Task<Customer> getById(int id)
        {
            var customer = await _context.Customers
                                        .Include(c => c.Address)
                                        .ThenInclude(a => a.AddressType)
                                        .SingleOrDefaultAsync(c => c.CustomerId == id);

            return customer;
        }

        public async Task<Customer> update(int id, Customer customer)
        {
            var updatedCustomer = _context.Update(customer);
            await _context.SaveChangesAsync();
            return updatedCustomer.Entity;
        }
    }
}