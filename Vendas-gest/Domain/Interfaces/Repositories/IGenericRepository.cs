using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    interface IGenericRepository<T> where T : Entity
    {
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
    }
}
