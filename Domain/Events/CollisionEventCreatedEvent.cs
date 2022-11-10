using CollisionsEventRestAPI.Domain.Common;
using CollisionsEventRestAPI.Domain.Entities;

namespace CollisionsEventRestAPI.Domain.Events
{
    public class CollisionEventCreatedEvent : BaseEvent
    {
        public CollisionEventCreatedEvent(CollisionEvent collisionEvent)
        {
            CollisionEvent = collisionEvent;
        }

        public CollisionEvent CollisionEvent { get; }
    }
}
