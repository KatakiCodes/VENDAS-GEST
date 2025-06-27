using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
