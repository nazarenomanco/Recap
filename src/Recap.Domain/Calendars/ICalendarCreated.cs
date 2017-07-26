using Radical.CQRS;

namespace Recap.Domain.Calendars
{
    public interface ICalendarCreated: IDomainEvent
    {
        string Name { get; set; }
    }
}
