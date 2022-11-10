using System.Text.Json.Serialization;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionStatus.Queries
{
    public record GetOperatorCollisionStatusQuery : IRequest<PaginatedList<CollisionEventDTO>>
    {
        public int OperatorId { get; set; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
