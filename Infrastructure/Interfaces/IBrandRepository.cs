using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand> GetAsync(int id);
        Task CreateAsync(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
    }
}
