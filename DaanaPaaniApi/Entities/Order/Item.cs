using System.Collections.Generic;

namespace DaanaPaaniApi.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public bool Combo { get; set; }
        public ICollection<ItemItem> ParentItems { get; set; }
        public ICollection<ItemItem> childItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}