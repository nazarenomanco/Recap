
using Radical.CQRS;

namespace Recap.Domain.Users
{
    interface IUserDeleted: IDomainEvent
    {
        string Name { get; set; }
    }
}
