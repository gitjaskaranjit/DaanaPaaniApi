using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        private readonly DataContext _db;

        public DriverRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}