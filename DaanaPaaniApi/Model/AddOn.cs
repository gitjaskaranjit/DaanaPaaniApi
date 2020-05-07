using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class AddOn
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
