using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IOrderService
    {
        IQueryable<Order> getAll();
        Task<Order> getById(int id);
        Task<Order> add(Order order);
        Task<Order> update(int id, Order order);
        void delete(Item item);
    }
}
