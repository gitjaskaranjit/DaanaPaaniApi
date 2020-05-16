using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DaanaPaaniApi.DTOs
{
    public class CustomerDTO : IValidatableObject
    {
        public int CustomerId { get; set; }

        [Sortable]
        [Searchable]
        public string Fullname { get; set; }

        [EmailAddress]
        [Searchable]
        public string Email { get; set; }

        [Required]
        [Searchable]
        public bool Active { get; set; }

        [Searchable]
        public string PhoneNumber { get; set; }

        [Searchable]
        public DateTime DateOfBirth { get; set; }

        [Sortable]
        [Searchable]
        public DateTime AddedDate { get; set; }

        [Searchable]
        public AddressDTO Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var httpContextService = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var customerService = (ICustomerService)validationContext.GetService(typeof(ICustomerService));
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
                if (customerService.getAll().Where(c => c.PhoneNumber == this.PhoneNumber).Select(c => c.CustomerId).FirstOrDefault() != this.CustomerId)
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