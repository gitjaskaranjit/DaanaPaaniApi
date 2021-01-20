using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _db;

        public ICustomerRepository Customer { get; private set; }

        public IItemRepository Item { get; private set; }

        public IOrderRepository Order { get; private set; }

        public IDriverRepository Driver { get; private set; }

        public ILocationRepository Location { get; private set; }



        public UnitOfWork(DataContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
            Item = new ItemRepository(_db);
            Order = new OrderRepository(_db);
            Driver = new DriverRepository(_db);
            Location = new LocationRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
           
        }
    }
}