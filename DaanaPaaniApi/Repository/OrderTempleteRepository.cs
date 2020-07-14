using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class OrderTempleteRepository : Repository<OrderTemplete>, IOrderTempleteRepository 
    {
        private readonly DataContext _db;

        public OrderTempleteRepository(DataContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderTemplete orderTemplete)
        {
            var items = _db.OrderItems.Where(o => o.OrderTempleteId == orderTemplete.OrderTempleteId);
            _db.OrderItems.RemoveRange(items);
            _db.OrderTempletes.Update(orderTemplete);
        }
    }
}
