using CollisionsEventRestAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollisionsEventRestAPI.Infrastructure.Interfaces
{
    public interface ICollisionEventsDbContext
    {
        DbSet<CollisionEvent> CollisionEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
