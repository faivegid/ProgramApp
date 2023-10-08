using ProgramApp.Domain.EfCore.BaseRepository;

namespace ProgramApp.Domain.ApplicationStages.Repository
{
    public interface IApplicationStageRepository : IRepository<ApplicationStage>
    {
        Task<List<ApplicationStage>> GetByProgram(Guid programId);
    }
}