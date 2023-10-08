using static System.Collections.Specialized.BitVector32;

namespace ProgramApp.Shared.ApplicationTemplate
{
    public class ApplicationTemplateDto
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public List<QuestionTemplate> PersonalInfo { get; set; }
        public List<QuestionGroup> Profile { get; set; }
        public List<QuestionTemplate> AdditionalQuestions { get; set; }
    }
}
