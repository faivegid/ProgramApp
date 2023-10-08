using ProgramApp.Shared.Enums;
using ProgramApp.Shared.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace ProgramApp.Shared.Programs
{
    public class ProgramCreateRto
    {
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
        public string ProgramBenefits { get; set; }
        public List<string> Skills { get; set; }
        public string ApplicationCriteria { get; set; }
        [Required]
        public ProgramType ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ApplicationOpenDate { get; set; }
        [Required]
        public DateTime ApplicationCloseDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public ProgramLocation ProgramLocation { get; set; }
        [LocationValidation("ProgramLocation", ErrorMessage ="Location is required for non remote location")]
        public string Location { get; set; }
        public EducationLevel MinimumQualification { get; set; }
        public int MaxNumberOfApplications { get; set; }
    }
}
