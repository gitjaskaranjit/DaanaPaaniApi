using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class OrderService : IRepository<Order>
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> add(Order order)
        {
            var newOrder = _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return newOrder.Entity;
        }

        public void delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> getAll()
        {
            return _context.Orders
                 .Include(o => o.AddOns)
                 .Include(o => o.Package)
                 .Include(o => o.Discount);
        }

        public Task<Order> getById(int id)
        {
            return _context.Orders
                .Include(o => o.AddOns)
                .Include(o => o.Package)
                .Include(o => o.Discount).SingleOrDefaultAsync(o => o.OrderId == id);
        }

        public Task<Order> update(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}