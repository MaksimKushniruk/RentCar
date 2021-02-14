using RentCar.DataAccess.EF;
using RentCar.DataAccess.Entities;
using RentCar.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Repositories
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
            if(coupon != null)
            {
                db.Coupons.Remove(coupon);
            }
        }
    }
}
