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
            var items = _db.ItemItems.Where(o => o.ParentItemId == item.ItemId);
            _db.RemoveRange(items);
            _db.Items.Update(item);
        }
    }
}