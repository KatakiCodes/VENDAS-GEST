using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    interface IGenericRepository<T> where T : Entity
    {
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
    }
}
