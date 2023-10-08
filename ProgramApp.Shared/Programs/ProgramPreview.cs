using ProgramApp.Shared.Enums;

namespace ProgramApp.Shared.Programs
{
    public class ProgramPreview
    {
        public Guid Id { get; set; }
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
        public string Location { get; set; }
    }
}
