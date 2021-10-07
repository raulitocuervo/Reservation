using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Shared.Validations
{
    public class GuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString() == "00000000-0000-0000-0000-000000000000")
                return new ValidationResult("This field is required");
            else if (!Guid.TryParse(value.ToString(), out var id))
                return new ValidationResult("Invalid Id Validation");
            else
                return ValidationResult.Success;
        }
    }
}
