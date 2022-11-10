using CollisionsEventRestAPI.Domain.Entities;

namespace CollisionsEventRestAPI.Application.Common.Interfaces
{
    public interface ICollisionStatusRepository
    {
        public Task<IQueryable<CollisionEvent>> GetOperatorCollisionStatusAsync(int operatorId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
