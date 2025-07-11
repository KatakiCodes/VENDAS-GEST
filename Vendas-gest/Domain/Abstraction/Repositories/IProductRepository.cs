using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAll(User user);
    }
}
