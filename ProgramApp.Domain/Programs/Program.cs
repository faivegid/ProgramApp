using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Domain.ApplicationTemplates;
using ProgramApp.Shared.Base;
using ProgramApp.Shared.Enums;

namespace ProgramApp.Domain.Programs
{
    public class Program : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ProgramBenefits { get; set; }
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
        public ApplicationTemplate ApplicationTemplate { get; set; }
        public ICollection<ApplicationStage> ApplicationStages { get; set; }

        public Program() : base() { Id = Guid.NewGuid(); }
    }
}
