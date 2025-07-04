using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetAll(User user);
    }
}
