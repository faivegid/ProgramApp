using ProgramApp.Shared.ApplicationTemplate;
using ProgramApp.Shared.Enums;

namespace ProgramApp.Shared.ApplicationStages
{
    public class ApplicationStageDto
    {
        public Guid Id { get; set; }
        public string StageName { get; set; }
        public StageType Type { get; set; }
        public bool IsVisibleToCanditate { get; set; }
        public VideoQuestionTemplate VideoQuestionTemplate { get; set; }
        public int Order { get; set; }
        public Guid ProgramId { get; set; }
    }
}
