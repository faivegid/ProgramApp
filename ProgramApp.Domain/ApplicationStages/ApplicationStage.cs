using ProgramApp.Shared.ApplicationTemplate;
using ProgramApp.Shared.Base;
using ProgramApp.Shared.Enums;

namespace ProgramApp.Domain.ApplicationStages
{
    public class ApplicationStage : BaseEntity<Guid>
    {
        public string StageName { get; set; }
        public StageType Type { get; set; }
        public bool IsVisibleToCanditate { get; set; }
        public VideoQuestionTemplate VideoQuestionTemplate { get; set; }
        public int Order { get; set; }
        public Guid ProgramId { get; set;}
    }
}