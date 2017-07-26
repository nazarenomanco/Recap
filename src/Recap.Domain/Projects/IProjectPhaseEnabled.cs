using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    public interface IProjectPhaseEnabled : IDomainEvent
    {
        Guid PhaseId { get; set; }
    }
}
