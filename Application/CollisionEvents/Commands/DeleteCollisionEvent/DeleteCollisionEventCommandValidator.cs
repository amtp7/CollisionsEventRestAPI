using FluentValidation;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.DeleteCollisionEvent
{
    public class DeleteCollisionEventCommandValidator : AbstractValidator<DeleteCollisionEventCommand>
    {
        public DeleteCollisionEventCommandValidator()
        {
            RuleFor(x => x.CollisionEventId)
                .NotNull();

            RuleFor(x => x.InvokerOperatorId)
                .NotNull();
        }
    }
}
