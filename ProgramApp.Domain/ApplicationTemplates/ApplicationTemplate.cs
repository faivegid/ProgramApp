using ProgramApp.Shared.ApplicationTemplate;
using ProgramApp.Shared.Base;

namespace ProgramApp.Domain.ApplicationTemplates
{
    public class ApplicationTemplate : BaseEntity<Guid>
    {
        public Guid ProgramId { get; set; }
        public List<QuestionTemplate> PersonalInfo { get; set; }
        public List<QuestionGroup> Profile { get; set; }
        public List<QuestionTemplate> AdditionalQuestions { get; set; }
    }
}

