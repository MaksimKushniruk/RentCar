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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _database;
        public CartService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Brand, BrandDto>();
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<Coupon, CouponDto>();
                cfg.CreateMap<Cart, CartDto>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Cart>, IEnumerable<CartDto>>(await _database.Carts.GetAllAsync());
        }

        public async Task<CartDto> GetAsync(string username)
        {
            Cart cart = null;
            if (!String.IsNullOrWhiteSpace(username))
            {
                cart = await _database.Carts.GetAsync(username);
            }
            if (cart == null)
            {
                throw new RentCarValidationException(String.Empty, "Cart is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Brand, BrandDto>();
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<Coupon, CouponDto>();
                cfg.CreateMap<Cart, CartDto>();
            }).CreateMapper();
            return mapper.Map<Cart, CartDto>(cart);
        }

        public async Task CreateAsync(CartDto cartDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<BrandDto, Brand>();
                cfg.CreateMap<CarDto, Car>()
                .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                .ForMember(dst => dst.Brand, opt => opt.Ignore());
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<CartDto, Cart>();
            }).CreateMapper();
            await _database.Carts.CreateAsync(mapper.Map<CartDto, Cart>(cartDto));
            await _database.SaveAsync();
        }

        public async Task EditAsync(CartDto cartDto)
        {
            Cart cart = await _database.Carts.GetAsync(cartDto.Username);
            if (cart == null)
            {
                throw new RentCarValidationException(String.Empty, "Cart is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<BrandDto, Brand>();
                cfg.CreateMap<CarDto, Car>()
                    .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                    .ForMember(dst => dst.Brand, opt => opt.Ignore());
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<CartDto, Cart>();
            }).CreateMapper();
            _database.Carts.Update(mapper.Map<CartDto, Cart>(cartDto));
            await _database.SaveAsync();
        }

        public async Task DeleteAsync(string username)
        {
            if (!String.IsNullOrEmpty(username))
            {
                _database.Carts.Delete(username);
                await _database.SaveAsync();
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
