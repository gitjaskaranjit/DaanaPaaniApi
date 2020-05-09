using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class AddressTypeService : IAddressTypeService
    {
        private readonly DataContext _context;
        public AddressTypeService(DataContext context)
        {
            _context = context;
        }
        public IQueryable<AddressType> getAll()
        {
            return _context.AddressTypes;
        }

        public async Task<AddressType> getById(int id)
        {
            return await  _context.AddressTypes.FindAsync(id);
        }
    }
}
