using System.Text.Json.Serialization;
using CollisionsEventRestAPI.Application.DTOs;
using MediatR;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent
{
    public record CreateCollisionEventCommand : IRequest<BaseDTO<Guid>>
    {
        public Guid MessageId { get; set; }
        public Guid CollisionEventId { get; set; }
        public string? SatelliteId { get; set; }
        public int OperatorId { get; set; }
        public double ProbabilityOfCollision { get; set; }
        public DateTime CollisionDate { get; set; }
        public string? ChaserObjectId { get; set; }

        [JsonIgnore]
        public int? InvokerOperatorId { get; set; }
    }
}
