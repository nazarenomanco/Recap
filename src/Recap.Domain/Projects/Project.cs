using System;
using Radical.CQRS;

namespace Recap.Domain.Projects
{
    class Project : Aggregate<Project.ProjectState>
    {
        public class ProjectState : AggregateState
        {
            public string Description { get; set; }
            public int Year { get; set; }
            public DateTime OpenDate { get; set; }
            public DateTime CloseDate { get; set; }
            public Guid CustomerId { get; set; }
            public bool Deleted { get; set; }
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
                    Deleted = false
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
                e.CloseDate = this.Data.CloseDate;
            });

        }

        public void DeleteProject()
        {
            if (this.Data.Deleted)
                return;

            this.Data.Deleted = true;

            this.RaiseEvent<IProjectDeleted>(e => { });

        }


    }
}
