using DaanaPaaniApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IOrderTempleteRepository : IRepository<OrderTemplete>
    {
       
        void Update(OrderTemplete orderTemplete);
    }
}
