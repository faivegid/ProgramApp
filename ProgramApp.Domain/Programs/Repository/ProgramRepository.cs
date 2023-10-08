using Microsoft.EntityFrameworkCore;
using ProgramApp.Domain.EfCore.BaseRepository;

namespace ProgramApp.Domain.Programs.Repository
{
    internal class ProgramRepository : GenericRepository<Program>, IProgramReposiitory
    {
        public ProgramRepository(EfCore.AppContext appContext) : base(appContext)
        {
        }

        public async Task<Program> Get(Guid programId)
        {
            return await dbSet
                .FirstOrDefaultAsync(x => x.Id == programId);
        }

        public async Task<List<Program>> GetList(int page, int contentPerPage)
        {
            return await dbSet
                .OrderBy(x => x.UpdatedAt)
                .Skip((page - 1) * contentPerPage)
                .Take(contentPerPage)
                .ToListAsync();
        }
    }
}
