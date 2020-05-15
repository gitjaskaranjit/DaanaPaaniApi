﻿using System.Collections.Generic;

namespace DaanaPaaniApi.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }

        public string Comment { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public ICollection<AddOn> AddOns { get; set; }
    }
}