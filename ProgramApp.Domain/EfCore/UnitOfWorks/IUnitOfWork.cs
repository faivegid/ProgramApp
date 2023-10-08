using ProgramApp.Domain.ApplicationStages.Repository;
using ProgramApp.Domain.ApplicationTemplates.Repository;
using ProgramApp.Domain.Programs.Repository;

namespace ProgramApp.Domain.EfCore.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        IApplicationStageRepository ApplicationStages { get; }
        IApplicationTemplateRepository ApplicationTemplates { get; }
        IProgramReposiitory Programs { get; }
    }
}
