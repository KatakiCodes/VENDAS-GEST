using Domain.Entities;
using System;
using System.Collections.Generic;
namespace Domain.Repositories
{
    interface IUserRepository
    {
        IEnumerable<User> GetAll(User user);
        User GetById(User user, Guid id);
        void Create(User user);
        void Update(User user);
    }
}
