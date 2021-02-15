using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface ICouponRepository
    {
        IEnumerable<Coupon> GetAll();
        Coupon Get(int id);
        IEnumerable<Coupon> Find(Func<Coupon, bool> predicate);
        void Create(Coupon coupon);
        void Update(Coupon coupon);
        void Delete(int id);
    }
}
