using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Helper
{
    public static class OrderTotalCalculator
    {
        public static int GetOrderTotal(int packagePrice, ICollection<AddOnDTO> addOns, DiscountDTO discount)
        {
            int OrderTotal = 0;
            int addontotal = 0;
            foreach (var addOn in addOns)
            {
                addontotal += addOn.Item.ItemPrice * addOn.Quantity;
            }
            OrderTotal = packagePrice + addontotal;
            if (discount.DiscountType == DiscountType.DOLLER)
            {
                OrderTotal = OrderTotal - discount.DiscountValue;
            }
            else
            {
                OrderTotal = OrderTotal - decimal.ToInt32(OrderTotal * (discount.DiscountValue / 100m));
            }
            return OrderTotal;
        }
    }
}