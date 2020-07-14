using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Entities
{
    public class OrderTemplete
    {
        public int OrderTempleteId { get; set; }
        public string OrderTempleteDesc { get; set; }
        public Discount Discount { get; set; }
        public int? DiscountId { get; set; }
        public ICollection<OrderItem> OrderTempleteItems { get; set; }
    }
}
