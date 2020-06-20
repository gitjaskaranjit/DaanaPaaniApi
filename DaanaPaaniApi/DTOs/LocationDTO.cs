using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class LocationDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string formatted_address { get; set; }

        public CustomerDTO customer { get; set; }
    }
}