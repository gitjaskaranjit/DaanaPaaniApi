﻿using DaanaPaaniApi.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IAddressTypeService
    {
        IQueryable<AddressType> getAll();

        Task<AddressType> getById(int id);
    }
}