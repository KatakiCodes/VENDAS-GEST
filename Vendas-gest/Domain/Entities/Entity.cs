using System;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
