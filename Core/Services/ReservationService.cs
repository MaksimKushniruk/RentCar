using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _database;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Brand, BrandDto>();
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<Coupon, CouponDto>();
                cfg.CreateMap<Reservation, ReservationDto>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationDto>>(await _database.Reservations.GetAllAsync());
        }

        public async Task<ReservationDto> GetAsync(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Reservation reservation = await _database.Reservations.GetAsync(id.Value);
            if (reservation == null)
            {
                throw new RentCarValidationException(String.Empty, "Reservation is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Brand, BrandDto>();
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<Coupon, CouponDto>();
                cfg.CreateMap<Reservation, ReservationDto>();
            }).CreateMapper();
            return mapper.Map<Reservation, ReservationDto>(reservation);
        }

        public async Task CreateAsync(ReservationDto reservationDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<BrandDto, Brand>();
                cfg.CreateMap<CarDto, Car>()
                .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                .ForMember(dst => dst.Brand, opt => opt.Ignore());
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<ReservationDto, Reservation>()
                    .ForMember(dst => dst.CarId, opt => opt.MapFrom(src => src.Car.Id))
                    .ForMember(dst => dst.Car, opt => opt.Ignore())
                    .ForMember(dst => dst.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                    .ForMember(dst => dst.Customer, opt => opt.Ignore())
                    .ForMember(dst => dst.CouponId, opt => opt.MapFrom(src => src.Coupon.Id))
                    .ForMember(dst => dst.Coupon, opt => opt.Ignore());
            }).CreateMapper();

            if (reservationDto.Car.Status == CarStatusDto.Free)
            {
                reservationDto.Car.Status = CarStatusDto.InRent;
                _database.Cars.Update(mapper.Map<CarDto, Car>(reservationDto.Car));
                await _database.Reservations.CreateAsync(mapper.Map<ReservationDto, Reservation>(reservationDto));
                await _database.SaveAsync();
            }
            else
            {
                throw new RentCarValidationException("Car", "Car already in rent");
            }

        }

        public async Task EditAsync(ReservationDto reservationDto)
        {
            Reservation reservation = await _database.Reservations.GetAsync(reservationDto.Id);
            if (reservation == null)
            {
                throw new RentCarValidationException(String.Empty, "Reservation is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<BrandDto, Brand>();
                cfg.CreateMap<CarDto, Car>()
                    .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                    .ForMember(dst => dst.Brand, opt => opt.Ignore());
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<ReservationDto, Reservation>();
            }).CreateMapper();
            _database.Reservations.Update(mapper.Map<ReservationDto, Reservation>(reservationDto));
            await _database.SaveAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id != null)
            {
                _database.Reservations.Delete(id.Value);
                await _database.SaveAsync();
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
