using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class AddressType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
