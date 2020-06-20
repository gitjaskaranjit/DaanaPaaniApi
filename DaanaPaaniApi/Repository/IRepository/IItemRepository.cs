using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        void Update(Item item);
    }
}