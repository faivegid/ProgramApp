using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Domain.ApplicationTemplates;
using ProgramApp.Domain.Programs;
using ProgramApp.Shared.ApplicationStages;
using ProgramApp.Shared.ApplicationTemplate;
using ProgramApp.Shared.Programs;

namespace ProgramApp.AppService
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<Program, ProgramDto>().ReverseMap();
            CreateMap<ApplicationTemplate, ApplicationTemplateDto>().ReverseMap();
            CreateMap<ApplicationStage, ApplicationStageDto>();
        }
    }
}
