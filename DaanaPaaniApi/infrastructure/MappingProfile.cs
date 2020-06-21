using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Helper;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using ProjNet.CoordinateSystems;
using System;

namespace DaanaPaaniApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ForMember(s => s.DriverName, d => d.MapFrom(x => x.driver.DriverName));
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
            CreateMap<PackageItem, PackageItemDTO>();
            CreateMap<PackageItemDTO, PackageItem>();
            CreateMap<Package, PackageDTO>();
            CreateMap<PackageDTO, Package>();
            CreateMap<OrderDTO, Order>().ForMember(s => s.OrderTotal, d => d.MapFrom<orderTotalResolver>());
            CreateMap<Order, OrderDTO>();
            CreateMap<AddOnDTO, AddOn>();
            CreateMap<AddOn, AddOnDTO>();
            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();
            CreateMap<DriverDTO, Driver>();
            CreateMap<Driver, DriverDTO>();
            CreateMap<DriverAddress, DriverAddressDTO>();
            CreateMap<DriverAddressDTO, DriverAddress>();
        }

        public class orderTotalResolver : IValueResolver<OrderDTO, Order, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public orderTotalResolver(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public int Resolve(OrderDTO source, Order destination, int member, ResolutionContext context)
            {
                return OrderTotalCalculator.GetOrderTotal(_unitOfWork.Package.GetPackagePrice(source.PackageId), source.AddOns, source.Discount);
            }
        }
    }
}