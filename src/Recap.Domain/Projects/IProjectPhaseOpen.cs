using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    public interface IProjectPhaseOpen:IDomainEvent
    {
        Guid PhaseId { get; set; }
        DateTime OpenDate { get; set; }
    }
}
