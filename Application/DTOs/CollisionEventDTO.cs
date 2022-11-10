namespace CollisionsEventRestAPI.Application.DTOs
{
    public class CollisionEventDTO : BaseDTO<Guid>
    {
        public Guid MessageId { get; set; }
        public Guid CollisionEventId { get; set; }
        public string? SatelliteId { get; set; }
        public int OperatorId { get; set; }
        public double ProbabilityOfCollision { get; set; }
        public DateTime CollisionDate { get; set; }
        public string? ChaserObjectId { get; set; }
    }
}
