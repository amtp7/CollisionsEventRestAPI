using CollisionsEventRestAPI.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CollisionsEventRestAPI.Application.CollisionEvents.EventHandlers
{
    public class CollisionEventCreatedEventHandler : INotificationHandler<CollisionEventCreatedEvent>
    {
        private readonly ILogger<CollisionEventCreatedEventHandler> _logger;

        public CollisionEventCreatedEventHandler(ILogger<CollisionEventCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CollisionEventCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CollisionEventRestAPI Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
