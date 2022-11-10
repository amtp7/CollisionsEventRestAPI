using System.Threading;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Domain.Entities;
using CollisionsEventRestAPI.Domain.Events;
using CollisionsEventRestAPI.Infrastructure.Interfaces;
using MediatR;

namespace CollisionsEventRestAPI.Infrastructure.Repositories
{
    public class CollisionEventsRepository : ICollisionEventsRepository
    {
        private readonly ICollisionEventsDbContext _collisionEventsDbContext;

        public CollisionEventsRepository(ICollisionEventsDbContext collisionEventsDbContext)
        {
            _collisionEventsDbContext = collisionEventsDbContext;
        }

        public async Task<CollisionEvent> GetCollisionEventAsync(Guid collisionEventId, CancellationToken cancellationToken)
        {
            var entity = await _collisionEventsDbContext.CollisionEvents.FindAsync(collisionEventId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CollisionEvent), collisionEventId);
            }

            return entity;
        }

        public async Task<Guid> CreateCollisionEventAsync(CollisionEvent collisionEvent, CancellationToken cancellationToken)
        {
            var existingEntity = await _collisionEventsDbContext.CollisionEvents.FindAsync(collisionEvent.CollisionEventId, cancellationToken);

            if (existingEntity != null)
            {
                throw new AlreadyExistsException(nameof(CollisionEvent), collisionEvent.CollisionEventId);
            }

            _collisionEventsDbContext.CollisionEvents.Add(collisionEvent);
            await _collisionEventsDbContext.SaveChangesAsync(cancellationToken);
            collisionEvent.AddDomainEvent(new CollisionEventCreatedEvent(collisionEvent));
                     
            return collisionEvent.CollisionEventId;
        }

        public async Task<Unit> DeleteCollisionEventAsync(Guid collisionEventId, CancellationToken cancellationToken)
        {
            var entityToDelete = await _collisionEventsDbContext.CollisionEvents.FindAsync(collisionEventId, cancellationToken);
       
            if (entityToDelete == null)
            {
                throw new NotFoundException(nameof(CollisionEvent), collisionEventId);
            }          

            _collisionEventsDbContext.CollisionEvents.Remove(entityToDelete);
            await _collisionEventsDbContext.SaveChangesAsync(cancellationToken);
            entityToDelete.AddDomainEvent(new CollisionEventDeletedEvent(entityToDelete));

            return Unit.Value;
        }
       
    }
}
