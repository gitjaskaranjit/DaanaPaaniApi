using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public interface IGeocodeService
    {
        bool Error { get; set; }

        Task<GeocodeResponse> GetLocationInfoAsync(Model.Address address);
    }
}