using Microsoft.EntityFrameworkCore;
using ProgramApp.Shared.Base;

namespace ProgramApp.Domain.EfCore.BaseRepository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppContext appContext;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(AppContext appContext)
        {
            this.appContext = appContext;
            dbSet = appContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(object key)
        {
            return await appContext.Set<TEntity>().FindAsync(key);
        }

        public void Insert(TEntity entity)
        {
            appContext.Set<TEntity>().Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            appContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            appContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            appContext.Set<TEntity>().UpdateRange(entities);
        }

        public void HardDelete(TEntity entity)
        {
            appContext.Set<TEntity>().Remove(entity);
        }

        public async Task<int> Count()
        {
            return await dbSet.CountAsync();
        }
    }
}
