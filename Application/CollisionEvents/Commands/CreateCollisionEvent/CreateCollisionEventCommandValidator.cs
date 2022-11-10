using FluentValidation;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Commands.CreateCollisionEvent
{
    public class CreateCollisionEventCommandValidator : AbstractValidator<CreateCollisionEventCommand>
    {
        public CreateCollisionEventCommandValidator()
        {
            RuleFor(x => x.MessageId)
                .NotNull();

            RuleFor(x => x.CollisionEventId)
                .NotNull();

            RuleFor(x => x.SatelliteId)
                .NotEmpty()
                .MaximumLength(9);

            RuleFor(x => x.OperatorId)
                .NotNull();

            RuleFor(x => x.ProbabilityOfCollision)
                .NotNull()
                .InclusiveBetween(0, 1)
                .WithMessage("Probability of collision must be between 0 and 1");

            RuleFor(x => x.CollisionDate)
                .NotNull();

            RuleFor(x => x.ChaserObjectId)
                .NotEmpty()
                .MaximumLength(9);

            RuleFor(x => x.InvokerOperatorId)
                .NotNull();

            RuleFor(x => x.InvokerOperatorId)
                .NotNull()
                .Equal(x => x.OperatorId);
        }
    }
}
