using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    public interface IProjectPhaseClosed : IDomainEvent
    {
        Guid PhaseId { get; set; }
        DateTime CloseDate { get; set; }
    }
}
