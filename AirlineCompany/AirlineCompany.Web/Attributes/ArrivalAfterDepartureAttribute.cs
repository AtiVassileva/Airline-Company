using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Attributes
{
    public class ArrivalAfterDepartureAttribute : ValidationAttribute
    {
        private readonly string _departureTimePropertyName;

        public ArrivalAfterDepartureAttribute(string departureTimePropertyName)
        {
            _departureTimePropertyName = departureTimePropertyName;
            ErrorMessage = "Времето на кацане трябва да е по-голямо от времето на излитане!";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var arrivalTime = (DateTime?)value;

            var departureTimeProperty = validationContext.ObjectType.GetProperty(_departureTimePropertyName);
            if (departureTimeProperty == null)
            {
                return new ValidationResult($"Не е намерено свойство с име {_departureTimePropertyName}");
            }

            var departureTime = (DateTime?)departureTimeProperty.GetValue(validationContext.ObjectInstance);

            if (arrivalTime.HasValue && departureTime.HasValue)
            {
                if (arrivalTime <= departureTime)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}