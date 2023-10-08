using ProgramApp.Shared.Enums;

namespace ProgramApp.Shared.Programs
{
    public class ProgramDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ProgramNenefits { get; set; }
        public List<string> Skills { get; set; }
        public string ApplicationCriteria { get; set; }
        public ProgramType ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ApplicationOpenDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }
        public int Duration { get; set; }
        public ProgramLocation ProgramLocation { get; set; }
        public string Location { get; set; }
        public EducationLevel MinimumQualification { get; set; }
        public int MaxNumberOfApplications { get; set; }
        public string CoverImage { get; set; }
    }
}
