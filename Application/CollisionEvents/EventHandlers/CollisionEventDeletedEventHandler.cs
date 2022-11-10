using CollisionsEventRestAPI.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CollisionsEventRestAPI.Application.CollisionEvents.EventHandlers
{
    public class CollisionEventDeletedEventHandler
    {
        private readonly ILogger<CollisionEventDeletedEventHandler> _logger;

        public CollisionEventDeletedEventHandler(ILogger<CollisionEventDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CollisionEventDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CollisionEventRestAPI Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
