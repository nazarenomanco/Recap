using Radical.CQRS;

namespace Recap.Domain.Users
{
    interface IUserCreated : IDomainEvent
    {
        string Name { get; set; }
    }
}
