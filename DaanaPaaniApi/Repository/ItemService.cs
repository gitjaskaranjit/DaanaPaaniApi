using DaanaPaaniApi.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class ItemService : IRepository<Item>
    {
        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<Item> add(Item item)
        {
            var itemsaved = await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            return itemsaved.Entity;
        }

        public async void delete(Item item)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Item> getAll()
        {
            return _context.Items;
        }

        public async Task<Item> getById(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> update(int id, Item item)
        {
            var updatedItem = _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return updatedItem.Entity;
        }
    }
}