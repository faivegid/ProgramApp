using ProgramApp.Shared.ApplicationStages;

namespace ProgramApp.AppService.ApplicationStages
{
    public interface IApplicationStageAppService
    {
        Task<ApplicationStageDto> CreateStage(ApplicationStageCreateRto createRto);
        Task<ApplicationStageDto> GetStageById(Guid stageId);
        Task<List<ApplicationStageDto>> GetStages(Guid programId);
    }
}