using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IlocationService
    {
        IQueryable<LocationInfo> getAllAsync();
    }
}