using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaanaPaaniApi.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Comment { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        [Sieve(CanFilter = true)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Sieve(CanFilter = true)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EndDate { get; set; } = null;

        public Discount Discount { get; set; }
        public int? DiscountId { get; set; }
        public int OrderTotal { get; set; }
    }
}