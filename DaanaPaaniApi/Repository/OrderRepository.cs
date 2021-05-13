using DaanaPaaniApi.Controllers;
using DaanaPaaniApi.Entities;
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


        public void Update(Order order)
        {
            var items = _db.OrderItems.Where(o => o.OrderId == order.OrderId);
            _db.RemoveRange(items);
            _db.Orders.Update(order);

        }
    }
}