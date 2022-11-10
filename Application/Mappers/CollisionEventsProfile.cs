using AutoMapper;
using CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent;
using CollisionsEventRestAPI.Application.DTOs;
using CollisionsEventRestAPI.Domain.Entities;

namespace CollisionsEventRestAPI.Application.Mappers
{
    public class CollisionEventsProfile : Profile
    {
        public CollisionEventsProfile()
        {
            CreateMap<CreateCollisionEventCommand, CollisionEvent>();
            CreateMap<CollisionEvent, CollisionEventDTO>();
            CreateMap<IQueryable<CollisionEvent>, IQueryable<CollisionEventDTO>>();
        }
    }
}
