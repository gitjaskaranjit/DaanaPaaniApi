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
        [Sortable]
        [Searchable]
        public string Fullname { get; set; }
        [EmailAddress]
        [Searchable]
        public string Email { get; set; }
        [Required]
        [Searchable]
        public bool Active { get; set; }
        [Searchable]
        public string PhoneNumber { get; set; }
        [Sortable]
        [Searchable]
        public DateTime BillDate { get; set; }
        [Searchable]
        public AddressDTO Address { get; set; }
    }
}
