using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IPackageRepository : IRepository<Package>
    {
        void Update(Package package);
    }
}