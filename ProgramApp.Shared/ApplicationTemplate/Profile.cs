namespace ProgramApp.Shared.ApplicationTemplate
{
    public class Profile
    {
        public bool IsEducationSelected { get; set; }
        public bool IsEducationManadatory { get; set; }
        public bool IsResumeSelected { get; set; }
        public bool IsResumeMandatory { get; set; }
        public bool IsExperienceSelected { get; set; }
        public bool IsExperienceMandatory { get; set; }
        public List<QuestionTemplate> AdditionalQuestions { get; set; } = new();
    }
}
