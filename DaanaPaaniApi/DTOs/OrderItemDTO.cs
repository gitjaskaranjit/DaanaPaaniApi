using System.Collections.Generic;

namespace DaanaPaaniApi.Controllers
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }
        public ICollection<ItemNCount> ItemNCounts { get; set; }

        public class ItemNCount
        {
            public string ItemName { get; set; }
            public int Quantity { get; set; }
        }
    }
}