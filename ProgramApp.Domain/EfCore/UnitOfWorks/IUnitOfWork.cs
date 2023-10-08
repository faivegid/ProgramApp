namespace ProgramApp.Domain.EfCore.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
