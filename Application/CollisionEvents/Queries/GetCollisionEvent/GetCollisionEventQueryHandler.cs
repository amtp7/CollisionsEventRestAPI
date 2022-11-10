using AutoMapper;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Application.DTOs;
using CollisionsEventRestAPI.Domain.Entities;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Queries.GetCollisionEvent
{
    public class GetCollisionEventQueryHandler : IRequestHandler<GetCollisionEventQuery, CollisionEventDTO>
    {
        private readonly ICollisionEventsRepository _collisionEventsRepository;
        private readonly IMapper _mapper;

        public GetCollisionEventQueryHandler(ICollisionEventsRepository collisionEventsRepository, IMapper mapper)
        {
            _collisionEventsRepository = collisionEventsRepository;
            _mapper = mapper;
        }

        public async Task<CollisionEventDTO> Handle(GetCollisionEventQuery request, CancellationToken cancellationToken)
        {          
            var collisionEvent = await _collisionEventsRepository.GetCollisionEventAsync(request.CollisionEventId, cancellationToken);

            if (request.InvokerOperatorId != collisionEvent.OperatorId)
            {
                throw new UnauthorizedException(nameof(CollisionEvent), request.CollisionEventId, request.InvokerOperatorId);
            }

            return _mapper.Map<CollisionEventDTO>(collisionEvent);
        }
    }
}
