using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballApp.Validatiors
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateCompareAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            if ((DateTime)value >= DateTime.Now) {
                return new ValidationResult("Footballer must be born!");
            }
            return ValidationResult.Success;
        }
    }
}