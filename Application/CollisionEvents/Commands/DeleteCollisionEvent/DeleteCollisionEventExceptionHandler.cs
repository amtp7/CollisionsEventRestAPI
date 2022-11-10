using System.Net;
using CollisionsEventRestAPI.Application.Common.Exceptions;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR;
using MediatR.Pipeline;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent
{
    public class DeleteCollisionEventExceptionHandler : RequestExceptionHandler<DeleteCollisionEventCommand, BaseDTO<Unit>, Exception>
    {
        private BaseDTO<Unit> _response = new BaseDTO<Unit>();

        protected override void Handle(DeleteCollisionEventCommand request, Exception exception, RequestExceptionHandlerState<BaseDTO<Unit>> state)
        {
            switch(exception)
            {
                case ValidationException:
                    _response.SetStatusCode(HttpStatusCode.BadRequest);
                    state.SetHandled(_response);
                    break;

                case NotFoundException:
                    _response.SetStatusCode(HttpStatusCode.NotFound);
                    state.SetHandled(_response);
                    break;

                default:
                    break;
            }
        }
    }
}
