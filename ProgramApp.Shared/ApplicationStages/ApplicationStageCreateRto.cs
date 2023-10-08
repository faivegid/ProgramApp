using ProgramApp.Shared.ApplicationTemplate;
using ProgramApp.Shared.Enums;
using ProgramApp.Shared.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace ProgramApp.Shared.ApplicationStages
{
    public class ApplicationStageCreateRto
    {
        [Required]
        public string StageName { get; set; }
        [Required]
        public StageType Type { get; set; }
        [Required]
        public bool IsVisibleToCanditate { get; set; }
        [ValidateVideoQuestion(ErrorMessage = "video Question settings is needed")]
        public VideoQuestionTemplate VideoQuestionTemplate { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public Guid ProgramId { get; set; }
        public Guid? StageId { get; set; }
    }
}
