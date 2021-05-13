using DaanaPaaniApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public Decimal CarriedBalance { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public Decimal InvoiceTotal { get; set; }
        public ICollection<InvoiceLineDTO> InvoiceLines { get; set; }
    }
}
