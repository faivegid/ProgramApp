namespace ProgramApp.Domain.EfCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _appContext;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task SaveChangesAsync()
        {
            await _appContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
