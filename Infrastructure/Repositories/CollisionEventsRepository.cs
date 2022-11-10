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

        public async Task<Guid> CreateCollisionEventAsync(CollisionEvent collisionEvent, CancellationToken cancellationToken)
        {
            var entityExists = (await _collisionEventsDbContext.CollisionEvents.FindAsync(collisionEvent.CollisionEventId, cancellationToken)) == null;

            if (entityExists)
            {
                throw new AlreadyExistsException(nameof(CollisionEvent), collisionEvent.CollisionEventId);
            }

            _collisionEventsDbContext.CollisionEvents.Add(collisionEvent);

            await _collisionEventsDbContext.SaveChangesAsync(cancellationToken);

            collisionEvent.AddDomainEvent(new CollisionEventCreatedEvent(collisionEvent));
                     
            return collisionEvent.CollisionEventId;
        }

        public async Task<Unit> DeleteCollisionEventAsync(Guid collisionEventId, int operatorId, CancellationToken cancellationToken)
        {
            var entityToDelete = await _collisionEventsDbContext.CollisionEvents.FindAsync(collisionEventId, cancellationToken);

            if (entityToDelete == null)
            {
                throw new NotFoundException(nameof(CollisionEvent), collisionEventId);
            }

            entityToDelete.AddDomainEvent(new CollisionEventDeletedEvent(entityToDelete));

            _collisionEventsDbContext.CollisionEvents.Remove(entityToDelete);

            await _collisionEventsDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
