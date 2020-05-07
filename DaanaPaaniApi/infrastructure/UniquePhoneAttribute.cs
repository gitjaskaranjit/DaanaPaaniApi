using DaanaPaaniApi.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public class UniquePhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
         var service =   (ICustomerService) validationContext.GetService(typeof(ICustomerService));
            var db = service.getAll().Select(c => c.PhoneNumber == value.ToString());

           if ( db != null)
            {
                return new ValidationResult("Phone Number alrady in use");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
