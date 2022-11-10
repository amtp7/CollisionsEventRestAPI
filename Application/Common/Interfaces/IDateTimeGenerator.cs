namespace CollisionsEventRestAPI.Application.Common.Interfaces
{
    public interface IDateTimeGenerator
    {
        DateTime Now { get; }
        DateTime InThirtyDays { get; }
    }
}
