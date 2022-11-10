using System.Reflection;
using CollisionsEventRestAPI.Domain.Entities;
using CollisionsEventRestAPI.Infrastructure.Common;
using CollisionsEventRestAPI.Infrastructure.Interfaces;
using CollisionsEventRestAPI.Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CollisionsEventRestAPI.Infrastructure.Persistence
{
    public class CollisionEventsDbContext : DbContext, ICollisionEventsDbContext
    {
        private readonly IMediator _mediator;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public CollisionEventsDbContext(
            DbContextOptions<CollisionEventsDbContext> options,
            IMediator mediator,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options)
        {
            _mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<CollisionEvent> CollisionEvents => Set<CollisionEvent>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
