using ProgramApp.Domain.EfCore.BaseRepository;

namespace ProgramApp.Domain.ApplicationTemplates.Repository
{
    public interface IApplicationTemplateRepository : IRepository<ApplicationTemplate>
    {
        Task<ApplicationTemplate> GetByProgram(Guid programId);
    }
}