using System.Net;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR.Pipeline;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Queries.GetCollisionEvent
{
    public class GetCollisionEventExceptionHandler : RequestExceptionHandler<GetCollisionEventQuery, CollisionEventDTO, Exception>
    {
        private CollisionEventDTO _response = new CollisionEventDTO();

        protected override void Handle(GetCollisionEventQuery request, Exception exception, RequestExceptionHandlerState<CollisionEventDTO> state)
        {
            switch (exception)
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
