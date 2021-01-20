using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;

namespace DaanaPaaniApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Driver, DriverDTO>().ReverseMap();
            CreateMap<DriverAddress, DriverAddressDTO>().ReverseMap();
            CreateMap<Discount, DiscountDTO>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<ItemDTO, Item>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ForMember(dest=>dest.ItemName,opt=>opt.MapFrom(src=>src.Item.ItemName));
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<ItemItem, ItemItemDTO>().ReverseMap();
            CreateMap<Item, ChildItemDTO>().ReverseMap();
        }

        //public class orderTotalResolver : IValueResolver<OrderDTO, Order, int>
        //{
        //    private readonly IUnitOfWork _unitOfWork;

        //    public orderTotalResolver(IUnitOfWork unitOfWork)
        //    {
        //        _unitOfWork = unitOfWork;
        //    }

        //    public int Resolve(OrderDTO source, Order destination, int member, ResolutionContext context)
        //    {
        //        return OrderTotalCalculator.GetOrderTotal(_unitOfWork.Package.GetPackagePrice(source.PackageId), source.AddOns, source.Discount);
        //    }
        //}
    }
}