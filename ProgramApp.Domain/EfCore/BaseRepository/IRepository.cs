using ProgramApp.Shared.Base;

namespace ProgramApp.Domain.EfCore.BaseRepository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> Count();
        Task<TEntity> GetById(object key);
        void HardDelete(TEntity entity);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
