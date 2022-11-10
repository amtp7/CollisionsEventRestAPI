using CollisionsEventRestAPI.Application.CollisionStatus.Queries;
using CollisionsEventRestAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CollisionsEventRestAPI.CollisionsEventRestAPI.Controllers
{
    public class CollisionStatusController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CollisionEventDTO>>> GetOperatorCollisionStatusAsync([FromQuery] GetOperatorCollisionStatusQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
