
using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    public interface IProjectCreated: IDomainEvent
    {
        string Description { get; set; }
        int Year { get; set; }
        DateTime OpenDate { get; set; }
        Guid CustomerId { get; set; }
    }
}
