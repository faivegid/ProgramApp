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
            CreateMap<Program, ProgramPreview>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.ProgramType == Shared.Enums.ProgramType.FullyRemote ? "Fullly Remote" : src.Location))
                .ReverseMap();
        }
    }
}
