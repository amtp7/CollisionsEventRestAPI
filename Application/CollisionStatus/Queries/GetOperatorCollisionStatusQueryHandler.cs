using AutoMapper;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.Common.Interfaces;
using CollisionsEventRestAPI.Application.DTOs;
using CollisionsEventRestAPI.Application.Mappers;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionStatus.Queries
{
    public class GetOperatorCollisionStatusQueryHandler : IRequestHandler<GetOperatorCollisionStatusQuery, PaginatedList<CollisionEventDTO>>
    {
        private readonly ICollisionStatusRepository _collisionStatusRepository;
        private readonly IMapper _mapper;

        public GetOperatorCollisionStatusQueryHandler(ICollisionStatusRepository collisionStatusRepository, IMapper mapper)
        {
            _collisionStatusRepository = collisionStatusRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CollisionEventDTO>> Handle(GetOperatorCollisionStatusQuery request, CancellationToken cancellationToken)
        {
            if (request.InvokerOperatorId != request.OperatorId)
            {
                throw new UnauthorizedException();
            }

            var entities = await _collisionStatusRepository.GetOperatorCollisionStatusAsync(
                request.OperatorId, 
                request.PageNumber, 
                request.PageSize, 
                cancellationToken);

            var dtos = entities.Select(entity => _mapper.Map<CollisionEventDTO>(entity));

            return await dtos.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}