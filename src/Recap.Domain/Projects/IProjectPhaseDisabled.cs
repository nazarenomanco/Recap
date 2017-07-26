

using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    public interface IProjectPhaseDisabled : IDomainEvent
    {
        Guid PhaseId { get; set; }
    }
}
