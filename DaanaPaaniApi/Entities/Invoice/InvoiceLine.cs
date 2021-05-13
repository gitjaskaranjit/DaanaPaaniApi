using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Entities
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }

    }
}
