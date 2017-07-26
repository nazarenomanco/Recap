using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radical.CQRS;
using Recap.Domain.ValueObjects;

namespace Recap.Domain.Calendars
{
    public class Calendar : Aggregate<Calendar.CalendarState>
    {
        public class CalendarState : AggregateState
        {
            public string Name { get; set; }
            public ISet<Activity> Activities { get; set; } = new HashSet<Activity>();
        }


        private Calendar(Calendar.CalendarState state)
            : base(state)
        {
        }

        public class Factory
        {
            public Calendar CreateNew(string nome)
            {
                var state = new CalendarState()
                {
                    Name = nome,
                    Activities = new HashSet<Activity>()
                };
                var aggregate = new Calendar(state);
                aggregate.SetupCompleted();
                return aggregate;
            }
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<ICalendarCreated>(e =>
            {
                e.Name = this.Data.Name;
            }); 
        }

        public Guid AddActivity(string customerName, string pizzaTaste)
        {
            if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            if (pizzaTaste == null) throw new ArgumentNullException(nameof(pizzaTaste));

            var order = new Activity();
            this.Data.Activities.Add(order);

            this.RaiseEvent<IActivityAdded>(e =>
            {
                //e.CustomerName = customerName;
                //e.PizzaTaste = pizzaTaste;
                //e.OrderId = order.Id;
            });

            return order.Id;

        }


    }
}
