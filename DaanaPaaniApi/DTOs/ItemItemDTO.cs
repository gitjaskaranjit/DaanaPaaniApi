using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class ItemItemDTO
    {
        public int Quantity { get; set; }
        public ChildItemDTO ChildItem { get; set; }
    }
}
