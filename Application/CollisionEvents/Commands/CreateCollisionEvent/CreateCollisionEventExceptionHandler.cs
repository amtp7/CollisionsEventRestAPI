using System.Net;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR.Pipeline;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent
{
    public class CreateCollisionEventExceptionHandler : RequestExceptionHandler<CreateCollisionEventCommand, BaseDTO<Guid>, Exception>
    {
        private BaseDTO<Guid> _response = new BaseDTO<Guid>();

        protected override void Handle(CreateCollisionEventCommand request, Exception exception, RequestExceptionHandlerState<BaseDTO<Guid>> state)
        {
            switch(exception)
            { 
                case ValidationException:
                    _response.SetStatusCode(HttpStatusCode.BadRequest);
                    state.SetHandled(_response);
                    break;

                case AlreadyExistsException:
                    _response.SetStatusCode(HttpStatusCode.Conflict);
                    state.SetHandled(_response);
                    break;

                default:
                    break;
            }
        }
    }
}
