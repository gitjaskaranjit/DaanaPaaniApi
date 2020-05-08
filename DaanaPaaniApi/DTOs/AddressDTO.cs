
using DaanaPaaniApi.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class AddressDTO
    {
        public int StreetNo { get; set; }
        [Searchable]
        public string StreetName { get; set; }
        [Searchable]
        public string City { get; set; }
        public string PostalCode { get; set; }

        public AddressTypeDTO AddressType { get; set; }
    }
}
