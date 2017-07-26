

using Radical.CQRS;

namespace Recap.Domain.Users
{
    public interface IUserEnabled: IDomainEvent
    {
        string Name { get; set; }
    }
}
