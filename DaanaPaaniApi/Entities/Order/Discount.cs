﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public int DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public Order Order { get; set; }
        public OrderTemplete OrderTempletes { get; set; }
    }
}