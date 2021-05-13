using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Helper
{
    public class DefaultCalculator : ICalculator
    {
       private readonly IUnitOfWork _unitOfWork;
        public DefaultCalculator(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        public decimal OrderTotalCalculator(ICollection<OrderItemDTO> orderItem, DiscountDTO discount)
        {
            var ItemsInDb = _unitOfWork.Item.GetAllAsync(include: o => o.Include(o => o.childItems).ThenInclude(i => i.ChildItem)).AsEnumerable().Where(i => orderItem.Select(o => o.ItemId).Contains(i.ItemId)).Select(x => new
            {
                item = x,
                quantity = orderItem.FirstOrDefault(i => i.ItemId == x.ItemId).Quantity
            }) ; 
            
           

            Decimal orderTotal = 0M;

            foreach (var item in ItemsInDb)
            {
                orderTotal += item.item.ItemPrice * item.quantity;
                
            }

            if(discount.DiscountType == DiscountType.DOLLER)
            {
                orderTotal = orderTotal - discount.DiscountValue;

            }
            else
            {
                orderTotal = orderTotal - ((discount.DiscountValue * orderTotal) / 100);
            }

            return orderTotal;
        }
    }
}
