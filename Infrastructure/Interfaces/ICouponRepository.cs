using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<Coupon> GetAsync(int id);
        Task<Coupon> GetByCodeAsync(string code);
        Task CreateAsync(Coupon coupon);
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(int id);
    }
}
