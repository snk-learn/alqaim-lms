using AlQaim.Lms.Domain;
using AlQaim.Lms.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlQaim.Lms.Infrastructure.Data
{
    public class QaimDbContext : DbContext
    {
        private readonly IDomainEventDispatcher? _dispatcher;

        public QaimDbContext(
            DbContextOptions<QaimDbContext> options, 
            IDomainEventDispatcher? dispatcher): base(options) 
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Course> Courses => Set<Course>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
             if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }
        public override int SaveChanges() =>
       SaveChangesAsync().GetAwaiter().GetResult();
    }

}
