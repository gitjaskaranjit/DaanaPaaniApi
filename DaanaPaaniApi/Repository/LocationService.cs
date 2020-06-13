using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class LocationService : IRepository<LocationInfo>
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public Task<LocationInfo> add(LocationInfo entity)
        {
            throw new NotSupportedException();
        }

        public void delete(LocationInfo entity)
        {
            throw new NotSupportedException();
        }

        public IQueryable<LocationInfo> getAll()
        {
            return _context.LocationInfos;
        }

        public Task<LocationInfo> getById(int id)
        {
            throw new NotSupportedException();
        }

        public Task<LocationInfo> update(int id, LocationInfo entity)
        {
            throw new NotSupportedException();
        }
    }
}