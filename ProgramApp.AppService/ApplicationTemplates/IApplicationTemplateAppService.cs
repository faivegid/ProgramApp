using ProgramApp.Shared.ApplicationTemplate;

namespace ProgramApp.AppService.ApplicationTemplates
{
    public interface IApplicationTemplateAppService
    {
        Task<ApplicationTemplateDto> CreateTemplate(ApplicationCreaeteRto creaeteRto);
        Task<ApplicationTemplateDto> GetTempalteById(Guid templateId);
        Task<ApplicationTemplateDto> GetTemplate(Guid programId);
    }
}