using ProgramApp.Shared.Enums;
using ProgramApp.Shared.Programs;
using System.ComponentModel.DataAnnotations;

namespace ProgramApp.Shared.ValidationAttributes
{
    internal class LocationValidation : ValidationAttribute
    {
        private readonly string _propertyName;

        public LocationValidation(string propertyName)
        {
            _propertyName = propertyName;
        }

        public override bool IsValid(object value)
        {
            return true; // We don't need to perform validation here.
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;
            var propertyInfo = model.GetType().GetProperty(_propertyName);

            if (propertyInfo != null)
            {
                var propertyValue = propertyInfo.GetValue(model);

                if (propertyValue != null)
                {
                    if ((int)propertyValue != (int)ProgramLocation.FullyRemote && value == null)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
