using ProgramApp.Shared.ApplicationStages;
using ProgramApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProgramApp.Shared.ValidationAttributes
{
    public class ValidateVideoQuestion: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true; // We don't need to perform validation here.
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (ApplicationStageCreateRto)validationContext.ObjectInstance;

            if (model.Type == StageType.VideoInterview && value == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
