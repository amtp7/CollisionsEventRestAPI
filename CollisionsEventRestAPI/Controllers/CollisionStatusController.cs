using CollisionsEventRestAPI.Application.CollisionStatus.Queries;
using CollisionsEventRestAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CollisionsEventRestAPI.CollisionsEventRestAPI.Controllers
{
    public class CollisionStatusController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CollisionEventDTO>>> GetOperatorCollisionStatusAsync([FromHeader] int operatorId, [FromQuery] GetOperatorCollisionStatusQuery query)
        {
            query.InvokerOperatorId = operatorId;

            return await Mediator.Send(query);
        }
    }
}
