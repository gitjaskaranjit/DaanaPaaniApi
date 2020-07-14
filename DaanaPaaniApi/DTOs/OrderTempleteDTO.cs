using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class OrderTempleteDTO
    {
        public int OrderTempleteId { get; set; }
        public string OrderTempleteDesc { get; set; }
        public DiscountDTO Discount { get; set; }
        public ICollection<OrderItemDTO> OrderTempleteItems { get; set; }
    }
}
