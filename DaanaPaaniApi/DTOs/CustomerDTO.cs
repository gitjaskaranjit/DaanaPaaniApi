using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using ProjNet.CoordinateSystems;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DaanaPaaniApi.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string Fullname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime AddedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AddressDTO Address { get; set; }

        public int? DriverId { get; set; } = null;
    }
}