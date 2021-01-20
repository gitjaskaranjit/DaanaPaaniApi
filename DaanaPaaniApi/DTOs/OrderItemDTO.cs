using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class OrderItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}