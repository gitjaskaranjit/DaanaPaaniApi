using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class OrderItemDTO
    {
        public ItemDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}