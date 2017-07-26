using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Domain.ValueObjects
{
    public class Activity
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Descpription { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ProjectPhaseId { get; set; }
    }
}
