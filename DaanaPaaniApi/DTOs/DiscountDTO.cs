using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class DiscountDTO
    {
        public int DiscountValue { get; set; }
        public int OrderId { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}