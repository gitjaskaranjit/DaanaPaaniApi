using DaanaPaaniApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IDriverRepository : IRepository<Driver>
    {
        void Update(Driver driver);
    }
}