
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DaanaPaaniApi.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string Fullname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AddressDTO Address { get; set; }

        public int? DriverId { get; set; } = null;
        public bool IsActive { get; set; }
    }
}