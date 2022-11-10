using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Domain.Entities;
using CollisionsEventRestAPI.Infrastructure.Interfaces;

namespace CollisionsEventRestAPI.Infrastructure.Repositories
{
    public class CollisionStatusRepository : ICollisionStatusRepository
    {
        private readonly ICollisionEventsDbContext _collisionEventsDbContext;
        private readonly IDateTimeGenerator _dateTimeGenerator;

        public CollisionStatusRepository(ICollisionEventsDbContext collisionEventsDbContext, IDateTimeGenerator dateTimeGenerator)
        {
            _collisionEventsDbContext = collisionEventsDbContext;
            _dateTimeGenerator = dateTimeGenerator;
        }

        public async Task<IQueryable<CollisionEvent>> GetOperatorCollisionStatusAsync(int operatorId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_collisionEventsDbContext.CollisionEvents
                                            .Where(collisionEvent => collisionEvent.OperatorId == operatorId
                                                && collisionEvent.ProbabilityOfCollision >= 0.75
                                                && DateTime.Compare(collisionEvent.CollisionDate, _dateTimeGenerator.Now) >= 0)
                                            .OrderBy(collisionEvent => collisionEvent.CollisionDate));
        }
    }
}
