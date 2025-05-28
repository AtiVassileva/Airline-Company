using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Web.Attributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is bool boolean && boolean;
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? $"Полето {name} трябва да бъде маркирано!";
        }
    }
}