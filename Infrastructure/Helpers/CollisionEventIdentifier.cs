using CollisionsEventRestAPI.Application.Common.Interfaces;

namespace CollisionsEventRestAPI.Infrastructure.Helpers

{
    public class CollisionEventIdentifier : ICollisionEventIdentifier
    {
        public Guid New => Guid.NewGuid();
    }
}
