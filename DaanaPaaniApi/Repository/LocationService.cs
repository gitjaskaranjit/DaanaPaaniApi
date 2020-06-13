using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class LocationService : IlocationService
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public IQueryable<LocationInfo> getAllAsync()
        {
            return _context.LocationInfos;
        }
    }
}