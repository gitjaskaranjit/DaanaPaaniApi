using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        private readonly DataContext _db;

        public PackageRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Package package)
        {
            var items = _db.PackageItems.Where(i => i.PackageId == package.PackageId);
            _db.PackageItems.RemoveRange(items);
            var packageInDb = _db.Packages.Include(p => p.PackageItems).FirstOrDefault(p => p.PackageId == package.PackageId);
            _db.Packages.Update(package);
        }

        public int GetPackagePrice(int id)
        {
            return _db.Packages.Where(p => p.PackageId == id).Select(p => p.PackagePrice).FirstOrDefault();
        }
    }
}