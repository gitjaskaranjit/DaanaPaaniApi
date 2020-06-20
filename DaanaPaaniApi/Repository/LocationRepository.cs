using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly DataContext _db;

        public LocationRepository(DataContext db) : base(db)
        {
            _db = db;
        }
    }
}