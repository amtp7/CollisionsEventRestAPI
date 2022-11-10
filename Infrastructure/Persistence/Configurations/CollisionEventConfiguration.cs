using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CollisionsEventRestAPI.Domain.Entities;

namespace CollisionsEventRestAPI.Infrastructure.Persistence.Configurations
{
    public class CollisionEventConfiguration : IEntityTypeConfiguration<CollisionEvent>
    {
        public void Configure(EntityTypeBuilder<CollisionEvent> builder)
        {
            builder.Property(t => t.MessageId)
                .IsRequired();

            builder.Property(t => t.CollisionEventId)
                .IsRequired();

            builder.Property(t => t.SatelliteId)
                .IsRequired();

            builder.Property(t => t.OperatorId)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(t => t.ProbabilityOfCollision)
                .IsRequired();

            builder.Property(t => t.CollisionDate)
                .IsRequired();

            builder.Property(t => t.ChaserObjectId)
                .IsRequired()
                .HasMaxLength(9);
        }
    }
}