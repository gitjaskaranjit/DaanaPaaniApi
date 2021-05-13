using DaanaPaaniApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public Decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
