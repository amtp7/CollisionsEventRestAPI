using CollisionsEventRestAPI.Application.DTOs;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent
{
    public record DeleteCollisionEventCommand : IRequest<BaseDTO<Unit>>
    {
        public Guid CollisionEventId { get; set; }
        public int InvokerOperatorId { get; set; }
    }
}
