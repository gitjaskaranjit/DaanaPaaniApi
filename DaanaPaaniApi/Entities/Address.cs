using System.ComponentModel.DataAnnotations;

namespace DaanaPaaniApi.Model
{
    public class Address
    {
        public int StreetNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }

        [Key]
        public int CustomerId { get; set; }

        public AddressType AddressType { get; set; }
    }
}