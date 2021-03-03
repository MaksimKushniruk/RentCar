using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetAsync(int id);
        Task CreateAsync(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
