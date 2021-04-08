using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using System.ComponentModel.DataAnnotations;

namespace DaanaPaaniApi.DTOs
{
    public class AddressDTO
    {
        [Range(1, 99999, ErrorMessage = "Street no. Should be greater than 0")]
        public int StreetNo { get; set; }

        [Required]
        public string StreetName { get; set; }

        public string City { get; set; }

        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Invalid postel code")]
        public string PostalCode { get; set; }

        public AddressType AddressType { get; set; }
    }
}