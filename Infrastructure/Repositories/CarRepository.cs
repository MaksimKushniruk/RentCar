using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    class CarRepository : ICarRepository
    {
        private readonly RentCarDbContext db;

        public CarRepository(RentCarDbContext context)
        {
            db = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars.Include(c => c.Brand).ToList();
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);
        }

        public void Update(Car car)
        {
            db.Cars.Update(car);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return db.Cars.Include(c => c.Brand).Where(predicate).ToList();
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
