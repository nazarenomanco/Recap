using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Domain.ValueObjects
{
    public class ProjectPhase
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string Descpription { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public int Order { get; set; }

        public ProjectPhase()
        {

        }
        public ProjectPhase(Guid projectId, string description, int order)
        {
            this.Id = Guid.NewGuid();
            this.ProjectId = projectId;
            this.Descpription = description;
            this.Enabled = true;
            this.Deleted = false;
            this.Order = order;
        }
    }
}
