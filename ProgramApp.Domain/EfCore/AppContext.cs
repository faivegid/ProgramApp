using Microsoft.EntityFrameworkCore;
using ProgramApp.Domain.ApplicationStages;
using ProgramApp.Domain.ApplicationTemplates;
using ProgramApp.Domain.Programs;
using ProgramApp.Shared.Base;

namespace ProgramApp.Domain.EfCore
{
    public class AppContext : DbContext
    {
        public DbSet<Program> Programs { get; set; }
        public DbSet<ApplicationTemplate> ApplicationTemplates { get; set; }
        public DbSet<ApplicationStage> ApplicationStages { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Program>()
                        .HasOne(p => p.ApplicationTemplate)
                        .WithOne()
                        .HasForeignKey<ApplicationTemplate>(at => at.ProgramId);

            modelBuilder.Entity<Program>().ToContainer("Programs").HasPartitionKey(o => o.Id);
            modelBuilder.Entity<ApplicationTemplate>().ToContainer("ApplicationTemplates").HasPartitionKey(o => o.Id);
            modelBuilder.Entity<ApplicationStage>().ToContainer("ApplicationStages").HasPartitionKey(o => o.Id);
        }
    }
}
