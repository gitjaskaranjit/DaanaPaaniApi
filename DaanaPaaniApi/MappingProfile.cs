using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>().ForMember(src=>src.AddressType,opt=>opt.Ignore())
                                            .ForMember(src=>src.AddressTypeId,opt=>opt.MapFrom(des=>des.AddressType.AddressTypeId));
            CreateMap<AddressType, AddressTypeDTO>();
            CreateMap<AddressTypeDTO, AddressType>();
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
            CreateMap<PackageItem, PackageItemDTO>();
            CreateMap<PackageItemDTO, PackageItem>();
            CreateMap<Package, PackageDTO>();
            CreateMap<PackageDTO, Package>();
        }
        
    }
}
