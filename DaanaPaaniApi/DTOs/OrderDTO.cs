using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public string Comment { get; set; }
        public PackageDTO Package { get; set; }

        public ICollection<AddOnDTO> AddOns { get; set; }
    }
}
