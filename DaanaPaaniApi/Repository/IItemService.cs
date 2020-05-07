using DaanaPaaniApi.Model;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IItemService
    {
        IQueryable<Item> getAll();
        Task<Item> getById(int id);
        Task<Item> add(Item item);
        Task<Item> update(int id, Item item);
        void delete(Item item);
    }
}
