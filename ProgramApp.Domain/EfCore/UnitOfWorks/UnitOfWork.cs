using ProgramApp.Domain.ApplicationStages.Repository;
using ProgramApp.Domain.ApplicationTemplates.Repository;
using ProgramApp.Domain.Programs.Repository;

namespace ProgramApp.Domain.EfCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _appContext;
        private IApplicationStageRepository applicationStageRepository;
        private IApplicationTemplateRepository applicationTemplateRepository;
        private IProgramReposiitory programReposiitory;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }
        public IApplicationStageRepository ApplicationStages => applicationStageRepository ??= new ApplicationStageRepository(_appContext);
        public IApplicationTemplateRepository ApplicationTemplates => applicationTemplateRepository ??= new ApplicationTemplateRepository(_appContext);
        public IProgramReposiitory Programs => programReposiitory ??= new ProgramRepository(_appContext);


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
