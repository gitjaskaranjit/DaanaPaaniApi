using System.Collections.Generic;

namespace DaanaPaaniApi.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public ICollection<AddOn> AddOns { get; set; }
        public ICollection<PackageItem> PackageItems { get; set; }
    }
}