using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand Get(int id);
        void Create(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
    }
}
