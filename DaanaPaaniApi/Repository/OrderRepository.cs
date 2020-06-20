using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DataContext _db;

        public OrderRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}