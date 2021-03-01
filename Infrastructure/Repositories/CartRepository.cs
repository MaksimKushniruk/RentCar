using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly RentCarDbContext db;
        public CartRepository(RentCarDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await db.Carts.AsNoTracking()
                .Include(c => c.Customer).AsNoTracking()
                .Include(c => c.Car)
                    .ThenInclude(car => car.Brand).AsNoTracking()
                .Include(c => c.Coupon).AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cart> GetAsync(string username)
        {
            return await db.Carts.AsNoTracking()
                .Include(c => c.Customer).AsNoTracking()
                .Include(c => c.Car)
                    .ThenInclude(car => car.Brand).AsNoTracking()
                .Include(c => c.Coupon).AsNoTracking()
                .FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task CreateAsync(Cart cart)
        {
            await db.Carts.AddAsync(cart);
        }

        public void Update(Cart cart)
        {
            db.Carts.Update(cart);
        }

        public void Delete(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart != null)
            {
                db.Carts.Remove(cart);
            }
        }
    }
}
