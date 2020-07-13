using DaanaPaaniApi.DTOs;

namespace DaanaPaaniApi.Model
{
    public class PackageItem
    {
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}