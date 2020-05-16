using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime DateOfBirth { get; set; }

        public DateTime AddedDate { get; set; }
        public bool Active { get; set; }
        public Address Address { get; set; }
        public LocationInfo locationInfo { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}