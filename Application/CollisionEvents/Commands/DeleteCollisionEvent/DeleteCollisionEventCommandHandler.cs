using System.Net;
using CollisionsEventRestAPI.Application.Common.Exceptions;
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
            var eventToDelete = await _collisionEventsRepository.GetCollisionEventAsync(request.CollisionEventId, cancellationToken);

            if (eventToDelete.OperatorId != request.InvokerOperatorId)
            {
                throw new UnauthorizedException();
            }

            var response = await _collisionEventsRepository.DeleteCollisionEventAsync(request.CollisionEventId, cancellationToken);

            return new BaseDTO<Unit>(response, HttpStatusCode.NoContent);
        }
    }
}
