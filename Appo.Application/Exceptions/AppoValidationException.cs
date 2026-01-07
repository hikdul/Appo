using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation.Results;

namespace Appo.Aplication.Exceptions
{
    public class AppoValidationException: Exception
    {
        public static List<string> ValidationErrors { get; set; } = [];

        public AppoValidationException(string errorMessage)
        {
            ValidationErrors.Add(errorMessage);
        }

        public AppoValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
