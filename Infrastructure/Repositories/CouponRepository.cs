using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly RentCarDbContext db;

        public CouponRepository(RentCarDbContext context)
        {
            db = context;
        }

        public IEnumerable<Coupon> GetAll()
        {
            return db.Coupons.ToList();
        }

        public Coupon Get(int id)
        {
            return db.Coupons.Find(id);
        }

        public Coupon GetByCode(string code)
        {
            // TODO: set CouponCode as Primary Key
            // return db.Coupons.Find(code); 
            return db.Coupons.FirstOrDefault(c => c.CouponCode == code);
        }

        public void Create(Coupon coupon)
        {
            db.Coupons.Add(coupon);
        }

        public void Update(Coupon coupon)
        {
            db.Coupons.Update(coupon);
        }

        public IEnumerable<Coupon> Find(Func<Coupon, bool> predicate)
        {
            return db.Coupons.Where(predicate).ToList();
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
