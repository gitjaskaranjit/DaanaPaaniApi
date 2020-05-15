using DaanaPaaniApi.infrastructure;

namespace DaanaPaaniApi.DTOs
{
    public class AddressTypeDTO
    {
        public int AddressTypeId { get; set; }

        [Searchable]
        public string AddressTypeName { get; set; }
    }
}