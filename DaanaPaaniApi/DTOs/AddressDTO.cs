using DaanaPaaniApi.Model;

namespace DaanaPaaniApi.DTOs
{
    public class AddressDTO
    {
        public int StreetNo { get; set; }

        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public AddressType AddressType { get; set; }
    }
}