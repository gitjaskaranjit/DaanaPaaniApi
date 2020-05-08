using DaanaPaaniApi.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class AddressTypeDTO
    {
        public int AddressTypeId { get; set; }
        [Searchable]
        public string AddressTypeName { get; set; }
    }
}
