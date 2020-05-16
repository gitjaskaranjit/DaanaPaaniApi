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
        public DiscountTypeDTO DiscountType { get; set; }
    }
}