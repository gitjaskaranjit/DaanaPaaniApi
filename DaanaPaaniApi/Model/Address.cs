using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class Address
    {
        public int StreetNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }
        [Key]
        public int CustomerId { get; set; }

        public AddressType AddressType { get; set; }
        public int AddressTypeId { get; set; }
    }
}
