using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DaanaPaaniApi.DTOs
{
    public class CustomerDTO : IValidatableObject
    {
        public int CustomerId { get; set; }

        public string Fullname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool Active { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime AddedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AddressDTO Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var httpContextService = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var customerService = (IRepository<Customer>)validationContext.GetService(typeof(IRepository<Customer>));
            var requestMethod = httpContextService.HttpContext.Request.Method;
            if (requestMethod.Equals("POST"))
            {
                if (customerService.getAll().Where(c => c.PhoneNumber == this.PhoneNumber).Any())
                {
                    yield return new ValidationResult($"Phone number '{PhoneNumber}' already in use");
                }
                else
                {
                    yield return ValidationResult.Success;
                }
            }
            if (requestMethod.Equals("PUT"))
            {
                var cus = customerService.getAll().Where(c => c.PhoneNumber == this.PhoneNumber);
                if (cus.Any() && cus.Select(c => c.CustomerId).FirstOrDefault() != CustomerId)
                {
                    yield return new ValidationResult($"Phone number '{PhoneNumber}' already in use");
                }
                else
                {
                    yield return ValidationResult.Success;
                }
            }
        }
    }
}