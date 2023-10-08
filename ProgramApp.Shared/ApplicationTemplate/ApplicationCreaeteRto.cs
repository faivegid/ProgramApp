using System.ComponentModel.DataAnnotations;

namespace ProgramApp.Shared.ApplicationTemplate
{
    public class ApplicationCreaeteRto
    {
        [Required]
        public Guid ProgramId { get; set; }
        [Required]
        public List<QuestionTemplate> PersonalInfo { get; set; }
        [Required]
        public Profile Profile { get; set; }
        [Required]
        public List<QuestionTemplate> AdditionalQuestions { get; set; }
    }
}
