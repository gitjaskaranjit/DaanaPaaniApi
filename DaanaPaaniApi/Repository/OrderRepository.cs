using DaanaPaaniApi.Controllers;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public Task<IEnumerable<OrderItemDTO>> GetOrderItems()
        {
           From 
        }

        public void Update(Order order)
        {
            var addOns = _db.AddOns.Where(a=>a.OrderId == order.OrderId);
            _db.AddOns.RemoveRange(addOns);
            _db.Orders.Update(order);
        }
    }
}