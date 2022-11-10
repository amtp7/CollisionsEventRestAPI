using CollisionsEventRestAPI.Application.Common.Interfaces;

namespace CollisionsEventRestAPI.Infrastructure.Helpers
{
    public class DateTimeGenerator : IDateTimeGenerator
    {
        public DateTime Now => DateTime.Now;
        public DateTime InThirtyDays => DateTime.Now.AddDays(30);
    }
}
