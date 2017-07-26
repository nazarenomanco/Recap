using System;
using System.Collections.Generic;
using System.Linq;
using Radical.CQRS;
using Recap.Domain.ValueObjects;

namespace Recap.Domain.Projects
{
    class Project : Aggregate<Project.ProjectState>
    {
        public class ProjectState : AggregateState
        {
            public string Description { get; set; }
            public int Year { get; set; }
            public DateTime OpenDate { get; set; }
            public DateTime? CloseDate { get; set; }
            public Guid CustomerId { get; set; }
            public bool Deleted { get; set; }
            public ISet<ProjectPhase> Phases { get; set; } = new HashSet<ProjectPhase>();
        }


        private Project(Project.ProjectState state)
        : base(state)
        {
        }

        public class Factory
        {
            public Project CreateNew(string description, int year, DateTime openDate, Guid customerId)
            {
                var state = new ProjectState()
                {
                    Description = description,
                    Year = year,
                    OpenDate = openDate,
                    CustomerId = customerId,
                    Deleted = false,
                    Phases = new HashSet<ProjectPhase>()
                    
                };
                var aggregate = new Project(state);
                aggregate.SetupCompleted();
                return aggregate;
            }
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<IProjectCreated>(e =>
            {
                e.Description = this.Data.Description;
                e.Year = this.Data.Year;
                e.OpenDate = this.Data.OpenDate;
                e.CustomerId = this.Data.CustomerId;
            });
        }

        public void CloseProject(DateTime closeDate)
        {

            this.Data.CloseDate = closeDate;

            this.RaiseEvent<IProjectClosed>(e =>
            {
                e.CloseDate = this.Data.CloseDate.Value;
            });

        }

        public void DeleteProject()
        {
            if (this.Data.Deleted)
                return;

            this.Data.Deleted = true;

            this.RaiseEvent<IProjectDeleted>(e => { });

        }

        public Guid AddPhase(string descrition, int order)
        {
            if (descrition == null) throw new ArgumentNullException(nameof(descrition));

            var phase = new ProjectPhase(Id, descrition, order);
            this.Data.Phases.Add(phase);

            this.RaiseEvent<IProjectPhaseAdded>(e =>
            {
                e.Description = descrition;
                e.PhaseId = phase.Id;
            });

            return phase.Id;
        }

        public void OpenPhase(Guid phaseId, DateTime openDate)
        {

            var phase = this.Data.Phases.Single(x => x.Id == phaseId);

            EnablePhase(phaseId);

            this.RaiseEvent<IProjectPhaseOpen>(e =>
            {
                e.PhaseId = phase.Id;
                e.OpenDate = openDate;
            });

        }

        public void ClosePhase(Guid phaseId, DateTime closeDate)
        {

            var phase = this.Data.Phases.Single(x => x.Id == phaseId);

            this.RaiseEvent<IProjectPhaseClosed>(e =>
            {
                e.PhaseId = phase.Id;
                e.CloseDate = closeDate;
            });

        }

        public void EnablePhase(Guid phaseId)
        {

            var phase = this.Data.Phases.Single(x => x.Id == phaseId);
            phase.Enabled = true;

            this.RaiseEvent<IProjectPhaseEnabled>(e =>
            {
                e.PhaseId = phase.Id;
            });

        }

        public void DisablePhase(Guid phaseId)
        {

            var phase = this.Data.Phases.Single(x => x.Id == phaseId);
            phase.Enabled = false;

            this.RaiseEvent<IProjectPhaseDisabled>(e =>
            {
                e.PhaseId = phase.Id;
            });

        }
    }
}
