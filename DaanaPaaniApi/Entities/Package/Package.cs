using System.Collections.Generic;

namespace DaanaPaaniApi.Model
{
    public class Package
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int PackagePrice { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PackageItem> PackageItems { get; set; }
    }
}