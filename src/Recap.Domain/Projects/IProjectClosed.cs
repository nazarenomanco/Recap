using System;
using Radical.CQRS;


namespace Recap.Domain.Projects
{
    interface IProjectClosed: IDomainEvent
    {
        DateTime CloseDate { get; set; }
    }
}
