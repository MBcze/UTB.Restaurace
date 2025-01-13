using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Globalization;

namespace UTB.Restaurace.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class PriceValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is string text)
            {
                if (decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} field must be a valid number (e.g., 5 or 4.99).");
                }
            }

            if (value is double || value is decimal || value is float || value is int)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The {validationContext.MemberName} field must be a valid numeric value.");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
            context.Attributes.Add("data-val-pricevalidation", $"The {context.ModelMetadata.Name} field must be a valid number (e.g., 5 or 4.99).");
        }
    }
}
