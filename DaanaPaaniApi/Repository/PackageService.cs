using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class PackageService : IRepository<Package>
    {
        private readonly DataContext _context;

        public PackageService(DataContext context)
        {
            _context = context;
        }

        public async Task<Package> add(Package package)
        {
            var NewPackage = _context.Packages.Update(package);
            await _context.SaveChangesAsync();
            return NewPackage.Entity;
        }

        public IQueryable<Package> getAll()
        {
            return _context.Packages.Include(p => p.PackageItems).ThenInclude(p => p.Item);
        }

        public async Task<Package> getById(int id)
        {
            return await _context.Packages.Include(p => p.PackageItems).ThenInclude(p => p.Item).SingleOrDefaultAsync(p => p.PackageId == id);
        }

        public Task<Package> update(int id, Package packge)
        {
            throw new NotImplementedException();
        }

        void IRepository<Package>.delete(Package entity)
        {
            throw new NotImplementedException();
        }
    }
}