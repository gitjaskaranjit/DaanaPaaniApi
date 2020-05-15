using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public Task<Order> add(Order order)
        {
            throw new NotImplementedException();
        }

        public void delete(Item item)
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