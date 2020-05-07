using DaanaPaaniApi.infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Model
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; } 
        public string Fullname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime BillDate { get; set; }
        public bool Active { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
