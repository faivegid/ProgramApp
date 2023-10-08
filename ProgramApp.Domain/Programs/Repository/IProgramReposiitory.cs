using ProgramApp.Domain.EfCore.BaseRepository;

namespace ProgramApp.Domain.Programs.Repository
{
    public interface IProgramReposiitory : IRepository<Program>
    {
        Task<Program> Get(Guid programId);
        Task<List<Program>> GetList(int page, int contentPerPage);
    }
}
