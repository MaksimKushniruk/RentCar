using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICouponService
    {
        Task<IEnumerable<CouponDto>> GetAllAsync();
        Task<CouponDto> GetAsync(int? id);
        Task CreateASync(CouponDto couponDto);
        void Edit(CouponDto couponDto);
        void Delete(int? id);
        void Dispose();
    }
}
