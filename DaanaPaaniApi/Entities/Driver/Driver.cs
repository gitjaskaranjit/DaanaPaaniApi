using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }

        [Phone]
        public string DriverPhone { get; set; }

        [EmailAddress]
        public String DriverEmail { get; set; }

        public string LicenseNo { get; set; }
        public DateTime LinceseExp { get; set; }
        public string DriverNote { get; set; }
        public ICollection<Customer> customers { get; set; }
    }
}