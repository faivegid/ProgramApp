using Microsoft.EntityFrameworkCore;
using ProgramApp.Domain.EfCore.BaseRepository;

namespace ProgramApp.Domain.ApplicationStages.Repository
{
    internal class ApplicationStageRepository : GenericRepository<ApplicationStage>, IApplicationStageRepository
    {
        public ApplicationStageRepository(EfCore.AppContext appContext) : base(appContext)
        {
        }

        public async Task<List<ApplicationStage>> GetByProgram(Guid programId)
        {
            return await dbSet.Where(x => x.ProgramId == programId).ToListAsync();
        }
    }
}
