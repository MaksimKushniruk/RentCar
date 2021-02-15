using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand Get(int id);
        IEnumerable<Brand> Find(Func<Brand, bool> predicate);
        void Create(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
    }
}
