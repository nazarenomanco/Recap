using System;
using Radical.CQRS;
using Recap.Domain.ValueObjects;

namespace Recap.Domain.Users
{
    public class User : Aggregate<User.UserState>
    {
        public class UserState : AggregateState
        {
            public string Name { get; set; }
            public string Passowrd { get; set; }
            public bool Suspended { get; set; }
            public bool Deleted { get; set; }
        }


        private User(User.UserState state)
            : base(state)
        {
        }

        public class Factory
        {
            public User CreateNew(string name, string password)
            {
                var state = new UserState()
                {
                    Name = name,
                    Passowrd = password,
                    Suspended = false, 
                    Deleted = false
                };
                var aggregate = new User(state);
                aggregate.SetupCompleted();
                return aggregate;
            }
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<IUserCreated>(e =>
            {
                e.Name = this.Data.Name;
            });
        }

        public void SuspendUser()
        {
            if (this.Data.Suspended)
                return;

            this.Data.Suspended = true;

            this.RaiseEvent<IUserSuspended>(e =>
            {
                e.Name = this.Data.Name;
            });

        }

        public void EnableUser()
        {
            if (!this.Data.Suspended)
                return;

            this.Data.Suspended = false;

            this.RaiseEvent<IUserEnabled>(e =>
            {
                e.Name = this.Data.Name;
            });

        }

        public void DeleteUser()
        {
            if (this.Data.Deleted)
                return;

            this.Data.Deleted = true;

            this.RaiseEvent<IUserDeleted>(e =>
            {
                e.Name = this.Data.Name;
            });

        }


    }
}
