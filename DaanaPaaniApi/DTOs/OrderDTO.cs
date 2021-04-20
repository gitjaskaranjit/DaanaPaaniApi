using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaanaPaaniApi.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
      //  public CustomerDTO Customer { get; set; }
        public string Comment { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } = null;

        public DiscountDTO Discount { get; set; }
        public decimal OrderTotal { get; set; }
    }
}