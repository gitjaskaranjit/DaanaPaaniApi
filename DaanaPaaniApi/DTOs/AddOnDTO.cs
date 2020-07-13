using DaanaPaaniApi.Model;

namespace DaanaPaaniApi.DTOs
{
    public class AddOnDTO :IorderItem
    {
        public int Quantity { get; set; }
        public ItemDTO Item { get; set; }
    }
}