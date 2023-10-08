using ProgramApp.Shared.Enums;

namespace ProgramApp.Shared.ApplicationTemplate
{
    public class QuestionTemplate 
    {
        public string Question { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; }
        public bool EnableOtherOptions { get; set; }
        public int MaxNumberOfOptions { get; set; }
        public bool IsMandatory { get; set; }
        public bool Show { get; set; }
        public VideoQuestionTemplate VideoQuestionTemplate { get; set; }
        public Guid? QuestionGroupId { get; set; }
    }
}
