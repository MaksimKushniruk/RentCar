using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICouponService
    {
        Task<IEnumerable<CouponDto>> GetAllAsync();
        Task<CouponDto> GetAsync(int? id);
        Task<CouponDto> GetByCodeAsync(string code);
        Task CreateAsync(CouponDto couponDto);
        Task EditAsync(CouponDto couponDto);
        Task DeleteAsync(int? id);
        void Dispose();
    }
}
