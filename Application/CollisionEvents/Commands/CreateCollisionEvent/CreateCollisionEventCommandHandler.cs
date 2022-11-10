using System.Net;
using AutoMapper;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Application.DTOs;
using CollisionsEventRestAPI.Domain.Entities;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent
{
    public class CreateCollisionEventCommandHandler : IRequestHandler<CreateCollisionEventCommand, BaseDTO<Guid>>
    {
        private readonly ICollisionEventsRepository _collisionEventsRepository;
        private readonly IMapper _mapper;

        public CreateCollisionEventCommandHandler(ICollisionEventsRepository collisionEventsRepository, IMapper mapper)
        {
            _collisionEventsRepository = collisionEventsRepository;
            _mapper = mapper;
        }

        public async Task<BaseDTO<Guid>> Handle(CreateCollisionEventCommand request, CancellationToken cancellationToken)
        {
            if (request.OperatorId != request.InvokerOperatorId)
            {
                throw new UnauthorizedException();
            }

            var entity = _mapper.Map<CollisionEvent>(request);
            var response = await _collisionEventsRepository.CreateCollisionEventAsync(entity, cancellationToken);

            return new BaseDTO<Guid>(response, HttpStatusCode.Created);
        }
    }
}