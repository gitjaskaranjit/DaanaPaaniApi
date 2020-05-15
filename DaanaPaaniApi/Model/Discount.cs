﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class Discount
    {
        public int DiscountValue { get; set; }
        public Order Order { get; set; }

        [Key]
        public int OrderId { get; set; }

        public DiscountType DiscountType { get; set; }
        public int DiscountTypeId { get; set; }
    }
}