using System.Net;
using CollisionsEventRestAPI.Application.CollisionStatus.Queries;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR;
using MediatR.Pipeline;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent
{
    public class GetOperatorCollisionStatusExceptionHandler : RequestExceptionHandler<GetOperatorCollisionStatusQuery, PaginatedList<CollisionEventDTO>, Exception>
    {
        private PaginatedList<CollisionEventDTO> _response = new PaginatedList<CollisionEventDTO>(new List<CollisionEventDTO>(), 0, 0, 0);

        protected override void Handle(GetOperatorCollisionStatusQuery request, Exception exception, RequestExceptionHandlerState<PaginatedList<CollisionEventDTO>> state)
        {
            switch(exception)
            {
                case ValidationException:
                    _response.SetStatusCode(HttpStatusCode.BadRequest);
                    state.SetHandled(_response);
                    break;

                case UnauthorizedException:
                    _response.SetStatusCode(HttpStatusCode.Unauthorized);
                    state.SetHandled(_response);
                    break;

                default:
                    break;
            }
        }
    }
}
