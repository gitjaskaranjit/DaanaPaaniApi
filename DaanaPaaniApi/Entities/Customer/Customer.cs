using DaanaPaaniApi.Entities;
using Sieve.Attributes;
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

        [Sieve(CanFilter = true, CanSort = true)]
        public string Fullname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Sieve(CanFilter = true)]
        public string PhoneNumber { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime DateOfBirth { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime AddedDate { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public Address Address { get; set; }

        public Location locationInfo { get; set; }
        public ICollection<Order> Order { get; set; }
        public int? driverId { get; set; }
        public Driver driver { get; set; }
    }
}