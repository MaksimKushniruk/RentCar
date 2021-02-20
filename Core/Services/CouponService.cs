using Core.DTO;
using Core.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Entities;
using Core.Validation;

namespace Core.Services
{
    public class CouponService : ICouponService
    {
        private readonly IUnitOfWork _database;
        public CouponService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<IEnumerable<CouponDto>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDto>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<IEnumerable<Coupon>, IEnumerable<CouponDto>>(await _database.Coupons.GetAllAsync());
        }

        public async Task<CouponDto> GetAsync(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Coupon coupon = await _database.Coupons.GetAsync(id.Value);
            if (coupon == null)
            {
                throw new RentCarValidationException(String.Empty, "Coupon is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDto>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<Coupon, CouponDto>(coupon);
        }

        public async Task<CouponDto> GetByCodeAsync(string code)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                throw new RentCarValidationException(String.Empty, "Code is not set");
            }
            Coupon coupon = await _database.Coupons.GetByCodeAsync(code);
            if (coupon == null)
            {
                throw new RentCarValidationException(String.Empty, "Coupon is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDto>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<Coupon, CouponDto>(coupon);
        }

        public async Task CreateASync(CouponDto couponDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CouponDto, Coupon>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            await _database.Coupons.CreateAsync(mapper.Map<CouponDto, Coupon>(couponDto));
            await _database.SaveAsync();
        }

        public async Task EditAsync(CouponDto couponDto)
        {
            Coupon coupon = await _database.Coupons.GetAsync(couponDto.Id);
            if (coupon == null)
            {
                throw new RentCarValidationException(String.Empty, "Coupon is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CouponDto, Coupon>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            coupon = mapper.Map<CouponDto, Coupon>(couponDto);
            _database.Coupons.Update(coupon);
            await _database.SaveAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id != null)
            {
                _database.Coupons.Delete(id.Value);
                await _database.SaveAsync();
            }
        }

        public void Dispose()
        {

        }
    }
}
