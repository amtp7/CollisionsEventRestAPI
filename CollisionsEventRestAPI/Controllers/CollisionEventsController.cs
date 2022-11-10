using CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent;
using CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent;
using CollisionsEventRestAPI.Application.CollisionEvents.Queries.GetCollisionEvent;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CollisionsEventRestAPI.CollisionsEventRestAPI.Controllers
{
    public class CollisionEventsController : ApiControllerBase
    {
        [HttpGet("{collisionEventId}")]
        public async Task<ActionResult<CollisionEventDTO>> GetAsync([FromHeader] int operatorId, Guid collisionEventId)
        {
            var query = new GetCollisionEventQuery();
            query.CollisionEventId = collisionEventId;
            query.InvokerOperatorId = operatorId;

            var response = await Mediator.Send(query);

            return StatusCode(response.GetStatusCode(), response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromHeader] int operatorId, CreateCollisionEventCommand command)
        {
            command.InvokerOperatorId = operatorId;

            var response = await Mediator.Send(command);

            return StatusCode(response.GetStatusCode(), response);
        }

        [HttpDelete("{collisionEventId}")]
        public async Task<ActionResult<Unit>> DeleteASync([FromHeader] int operatorId, Guid collisionEventId)
        {
            var response = await Mediator.Send(new DeleteCollisionEventCommand 
            {
                CollisionEventId = collisionEventId,
                InvokerOperatorId = operatorId
            });

            return StatusCode(response.GetStatusCode(), response);
        }
    }
}
