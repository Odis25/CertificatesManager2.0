using System;
using System.ComponentModel.DataAnnotations;

namespace CertificatesModel.Validation.Attributes
{
    public class DateLessOrEqualThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateLessOrEqualThanAttribute(string comparisionProperty)
        {
            _comparisonProperty = comparisionProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            var property = context.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(context.ObjectInstance);

            if (currentValue <= comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
