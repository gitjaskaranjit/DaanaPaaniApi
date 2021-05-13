using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaanaPaaniApi.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Comment { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EndDate { get; set; } = null;

        public Discount Discount { get; set; }
        public int? DiscountId { get; set; }
        public decimal OrderTotal { get; set; }
    }
}