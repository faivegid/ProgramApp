using Microsoft.EntityFrameworkCore;
using ProgramApp.Shared.Base;

namespace ProgramApp.Domain.EfCore
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity<Guid>>())
            {
                if (item.State == EntityState.Added && item.Entity.Id == Guid.Empty)
                {
                    item.Entity.Id = Guid.NewGuid();
                }
            }

            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.UtcNow;
                        item.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
