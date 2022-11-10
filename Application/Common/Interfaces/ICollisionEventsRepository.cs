using CollisionsEventRestAPI.Domain.Entities;
using MediatR;

namespace CollisionsEventRestAPI.Application.Common.Interfaces
{
    public interface ICollisionEventsRepository
    {
        public Task<CollisionEvent> GetCollisionEventAsync(Guid collisionEventId, CancellationToken cancellationToken);
        public Task<Guid> CreateCollisionEventAsync(CollisionEvent collisionEvent, CancellationToken cancellationToken);
        public Task<Unit> DeleteCollisionEventAsync(Guid collisionEventId, CancellationToken cancellationToken);
    }
}
