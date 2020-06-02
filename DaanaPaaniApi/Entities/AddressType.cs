using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaanaPaaniApi.Model
{
    public enum AddressType
    {
        FRONTDOOR,
        BASEMENT,
        APARTMENT,
        UNKNOWN
    }
}