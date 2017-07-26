
using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    public interface IProjectPhaseAdded: IDomainEvent
    {
        string Description { get; set; }
        DateTime OpenDate { get; set; }
        Guid PhaseId { get; set; }
    }
}
