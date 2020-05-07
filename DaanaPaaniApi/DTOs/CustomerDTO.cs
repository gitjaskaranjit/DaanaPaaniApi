using DaanaPaaniApi.infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.DTOs
{
    public class CustomerDTO
    {

        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime BillDate { get; set; }
        public AddressDTO Address { get; set; }
    }
}
