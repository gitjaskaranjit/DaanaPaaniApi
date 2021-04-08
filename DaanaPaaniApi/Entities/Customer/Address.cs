using System.ComponentModel.DataAnnotations;

namespace DaanaPaaniApi.Entities
{
    public class Address
    {
        [MinLength(1, ErrorMessage = "Street no. Should be greater than 0")]
        public int StreetNo { get; set; }

        [Required]
        public string StreetName { get; set; }

        public string City { get; set; }

        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Invalid postel code")]
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }

        [Key]
        public int CustomerId { get; set; }

        public AddressType AddressType { get; set; }
    }
}