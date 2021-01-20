using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Entities
{
    public class ItemItem
    {
        public int ParentItemId { get; set; }
        public int ChildItemId { get; set; }
        public int Quantity { get; set; }
        public Item ParentItem { get; set; }
        public Item ChildItem { get; set; }
    }
}
