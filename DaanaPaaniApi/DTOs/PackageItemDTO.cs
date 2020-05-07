using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class PackageItemDTO
    {
        public ItemDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}
