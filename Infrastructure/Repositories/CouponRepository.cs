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
    public class CouponRepository : ICouponRepository
    {
        private readonly RentCarDbContext db;

        public CouponRepository(RentCarDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            return await db.Coupons.AsNoTracking().ToListAsync();
        }

        public async Task<Coupon> GetAsync(int id)
        {
            return await db.Coupons.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Coupon> GetByCodeAsync(string code)
        {
            return await db.Coupons.FirstOrDefaultAsync(c => c.CouponCode == code);
        }

        public async Task CreateAsync(Coupon coupon)
        {
            await db.Coupons.AddAsync(coupon);
        }

        public void Update(Coupon coupon)
        {
            db.Coupons.Update(coupon);
        }

        public void Delete(int id)
        {
            Coupon coupon = db.Coupons.Find(id);
            if (coupon != null)
            {
                db.Coupons.Remove(coupon);
            }
        }
    }
}
