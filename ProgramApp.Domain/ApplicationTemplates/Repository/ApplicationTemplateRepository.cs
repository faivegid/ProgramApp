using Microsoft.EntityFrameworkCore;
using ProgramApp.Domain.EfCore.BaseRepository;

namespace ProgramApp.Domain.ApplicationTemplates.Repository
{
    internal class ApplicationTemplateRepository : GenericRepository<ApplicationTemplate>, IApplicationTemplateRepository
    {
        public ApplicationTemplateRepository(EfCore.AppContext appContext) : base(appContext)
        {
        }

        public async Task<ApplicationTemplate> GetByProgram(Guid programId)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.ProgramId == programId);
        }
    }
}
