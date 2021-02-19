using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class CarRepository : ICarRepository
    {
        private readonly RentCarDbContext db;

        public CarRepository(RentCarDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await db.Cars.Include(c => c.Brand).ToListAsync();
        }

        public async Task<Car> GetAsync(int id)
        {
            return await db.Cars.Include(c => c.Brand).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Car car)
        {
            await db.Cars.AddAsync(car);
        }

        public void Update(Car car)
        {
            db.Cars.Update(car);
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
            }
        }
    }
}
