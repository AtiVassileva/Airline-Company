using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Attributes
{
    public class DifferentFromAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DifferentFromAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
            ErrorMessage = "Началната и крайната дестинация не могат да са еднакви!";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value;
            var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (otherProperty == null)
            {
                return new ValidationResult($"Не е намерено свойство с име {_otherPropertyName}");
            }

            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            if (currentValue != null && otherValue != null && currentValue.Equals(otherValue))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}