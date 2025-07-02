using Flunt.Notifications;
using System;

namespace Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
