using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Helpers.Validations
{
    public class FirstCapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
                return new ValidationResult("La primera letra tiene que ser mayuscua");

            return ValidationResult.Success;
        }
    }
}