using Radical.CQRS;

namespace Recap.Domain.Users
{
    interface IUserSuspended : IDomainEvent
    {
        string Name { get; set; }
    }
}
