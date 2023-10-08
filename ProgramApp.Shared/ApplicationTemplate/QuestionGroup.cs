namespace ProgramApp.Shared.ApplicationTemplate
{
    public class QuestionGroup 
    {
        public string Name { get; set; }
        public bool IsMandatory { get; set; }
        public List<QuestionTemplate> Questions { get; set; }
    }
}
