using CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent;
using CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CollisionsEventRestAPI.CollisionsEventRestAPI.Controllers
{
    public class CollisionEventsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromHeader] int invokerOperatorId, CreateCollisionEventCommand command)
        {
            command.InvokerOperatorId = invokerOperatorId;

            var response = await Mediator.Send(command);

            return StatusCode(response.GetStatusCode(), response);
        }

        [HttpDelete("{collisionEventId}")]
        public async Task<ActionResult<Unit>> DeleteASync([FromHeader] int invokerOperatorId, [FromQuery] Guid collisionEventId)
        {
            var response = await Mediator.Send(new DeleteCollisionEventCommand 
            {
                CollisionEventId = collisionEventId,
                InvokerOperatorId = invokerOperatorId
            });

            return StatusCode(response.GetStatusCode(), response);
        }
    }
}
