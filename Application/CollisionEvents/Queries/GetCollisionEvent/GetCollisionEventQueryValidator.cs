using FluentValidation;

namespace CollisionsEventRestAPI.Application.CollisionEvents.Queries.GetCollisionEvent
{
    public class GetCollisionEventQueryValidator : AbstractValidator<GetCollisionEventQuery>
    {
        public GetCollisionEventQueryValidator()
        {
            RuleFor(x => x.InvokerOperatorId)
                .NotNull();

            RuleFor(x => x.CollisionEventId)
                .NotNull();
        }
    }
}
