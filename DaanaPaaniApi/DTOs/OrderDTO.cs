using DaanaPaaniApi.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public string Comment { get; set; }
        public PackageDTO Package { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<AddOnDTO> AddOns { get; set; }
        public DiscountDTO discount { get; set; }
    }
}