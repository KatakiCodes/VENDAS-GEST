using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Abstraction.Repositories
{
    interface ISaleRepository : IGenericRepository<Sale>
    {
        IEnumerable<Sale> GetAll(User user);
    }
}
