using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Entities
{
    public class DriverAddress
    {
        public int StreetNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public Driver driver { get; set; }

        [Key]
        public int DriverId { get; set; }
    }
}