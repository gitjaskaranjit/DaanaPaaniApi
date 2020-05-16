using DaanaPaaniApi.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public interface IGoogleGeocode
    {
        bool error { get; set; }

        Task<GeocodeResponse> GetLocationInfoAsync(Address address);
    }
}