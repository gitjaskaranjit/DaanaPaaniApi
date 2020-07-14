using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly DataContext _db;

        public ItemRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}