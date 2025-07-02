using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll(Product user);
        User GetById(Product product, Guid id);
        void Create(Product product);
        void Update(Product product);
    }
}
