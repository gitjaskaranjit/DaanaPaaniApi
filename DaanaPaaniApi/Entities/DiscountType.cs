using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class DiscountType
    {
        public int DiscountTypeId { get; set; }
        public string DiscountTypeName { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
}