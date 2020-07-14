using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaanaPaaniApi.Entities
{
    public enum AddressType
    {
        FRONTDOOR,
        BASEMENT,
        APARTMENT,
        UNKNOWN
    }
}