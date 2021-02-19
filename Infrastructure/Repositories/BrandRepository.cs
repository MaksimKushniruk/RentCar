using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly RentCarDbContext db;

        public BrandRepository(RentCarDbContext context)
        {
            db = context;
        }

        public IEnumerable<Brand> GetAll()
        {
            return db.Brands.Include(b => b.Cars).ToList();
        }

        public Brand Get(int id)
        {
            return db.Brands.Include(b => b.Cars).FirstOrDefault(b => id == b.Id);
        }

        public void Create(Brand brand)
        {
            db.Brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            db.Brands.Update(brand);
        }

        public void Delete(int id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand != null)
            {
                db.Brands.Remove(brand);
            }
        }
    }
}
