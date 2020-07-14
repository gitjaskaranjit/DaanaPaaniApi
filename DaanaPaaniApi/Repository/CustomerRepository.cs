using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected readonly DataContext _db;

        public CustomerRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer customer)
        {
            _db.Customers.UpdateRange(customer);
        }
    }
}