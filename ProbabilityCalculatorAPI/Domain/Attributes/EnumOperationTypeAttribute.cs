using System.ComponentModel.DataAnnotations;

namespace ProbabilityCalculatorAPI.Model
{
    public class EnumOperationTypeAttribute : ValidationAttribute
    {
        private readonly Type _operationType;

        public EnumOperationTypeAttribute(Type operationType)
        {
            if (!operationType.IsEnum)
                throw new ArgumentException("EnumOperationTypeAttribute can only be used with enums.");

            _operationType = operationType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Operation is required.");
            }
             
            var valueString = value.ToString();

            if (valueString == null)
            {
                return new ValidationResult("Invalid operation type.");
            }

            var validEnumNames = Enum.GetNames(_operationType).Select(n => n.ToLower());

            if (validEnumNames.Contains(valueString.ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"Invalid operation type. Allowed values are: {string.Join(", ", Enum.GetNames(_operationType))}");
        }
    }
}
