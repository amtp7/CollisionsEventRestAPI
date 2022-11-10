using System.Net;
using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent
{
    public class DeleteCollisionEventCommandHandler : IRequestHandler<DeleteCollisionEventCommand, BaseDTO<Unit>>
    {
        private readonly ICollisionEventsRepository _collisionEventsRepository;

        public DeleteCollisionEventCommandHandler(ICollisionEventsRepository collisionEventsRepository)
        {
            _collisionEventsRepository = collisionEventsRepository;
        }

        public async Task<BaseDTO<Unit>> Handle(DeleteCollisionEventCommand request, CancellationToken cancellationToken)
        {
            var response = await _collisionEventsRepository.DeleteCollisionEventAsync(request.CollisionEventId, request.InvokerOperatorId, cancellationToken);

            return new BaseDTO<Unit>(response, HttpStatusCode.NoContent);
        }
    }
}
