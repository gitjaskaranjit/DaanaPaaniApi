using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Sieve(CanFilter = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Sieve(CanFilter = true)]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } = null;

        public ICollection<AddOn> AddOns { get; set; }
        public Discount Discount { get; set; }
        public int OrderTotal { get; set; }
    }
}