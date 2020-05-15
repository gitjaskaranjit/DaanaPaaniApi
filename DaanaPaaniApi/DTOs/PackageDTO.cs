using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class PackageDTO
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int PackagePrice { get; set; }
        public ICollection<PackageItemDTO> PackageItems { get; set; }
    }
}