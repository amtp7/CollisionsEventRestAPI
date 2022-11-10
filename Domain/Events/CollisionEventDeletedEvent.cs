using CollisionsEventRestAPI.Domain.Common;
using CollisionsEventRestAPI.Domain.Entities;

namespace CollisionsEventRestAPI.Domain.Events
{
    public class CollisionEventDeletedEvent : BaseEvent
    {
        public CollisionEventDeletedEvent(CollisionEvent collisionEvent)
        {
            CollisionEvent = collisionEvent;
        }

        public CollisionEvent CollisionEvent { get; }
    }
}
