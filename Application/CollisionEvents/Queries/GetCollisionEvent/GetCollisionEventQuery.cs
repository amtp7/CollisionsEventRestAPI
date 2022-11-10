using CollisionsEventRestAPI.Application.DTOs;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Queries.GetCollisionEvent
{
    public record GetCollisionEventQuery : IRequest<CollisionEventDTO>
    {
        public Guid CollisionEventId { get; set; }
        public int InvokerOperatorId { get; set; }
    }
}
