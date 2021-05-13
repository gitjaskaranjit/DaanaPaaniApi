using DaanaPaaniApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Helper
{
    public interface ICalculator
    {
        Decimal OrderTotalCalculator(ICollection<OrderItemDTO> orderItem,DiscountDTO discount);

    }
}
