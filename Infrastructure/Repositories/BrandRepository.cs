using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly RentCarDbContext db;

        public BrandRepository(RentCarDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await db.Brands.AsNoTracking().Include(b => b.Cars).AsNoTracking().ToListAsync();
        }

        public async Task<Brand> GetAsync(int id)
        {
            return await db.Brands.AsNoTracking().Include(b => b.Cars).AsNoTracking().FirstOrDefaultAsync(b => id == b.Id);
        }

        public async Task CreateAsync(Brand brand)
        {
            await db.Brands.AddAsync(brand);
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
