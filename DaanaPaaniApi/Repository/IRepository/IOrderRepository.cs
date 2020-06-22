using DaanaPaaniApi.Controllers;
using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
        Task<IEnumerable<OrderItemDTO>> GetOrderItems();
    }
}