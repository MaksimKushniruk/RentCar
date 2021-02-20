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
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _database;
        public CarService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Brand, BrandDto>()
                    .ForMember(dst => dst.Cars, opt => opt.Ignore());
                cfg.CreateMap<Car, CarDto>()
                    .ForMember(dst => dst.Brand, opt => opt.MapFrom(car => car.Brand));
            }).CreateMapper();
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDto>>(await _database.Cars.GetAllAsync());
        }

        public async Task<CarDto> GetAsync(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Car car = await _database.Cars.GetAsync(id.Value);
            if (car == null)
            {
                throw new RentCarValidationException(String.Empty, "Car is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Brand, BrandDto>()
                    .ForMember(dst => dst.Cars, opt => opt.Ignore());
                cfg.CreateMap<Car, CarDto>()
                    .ForMember(dst => dst.Brand, opt => opt.MapFrom(car => car.Brand));
            }).CreateMapper();
            return mapper.Map<Car, CarDto>(car);
        }
        
        public async Task CreateAsync(CarDto carDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandDto, Brand>()
                    .ForMember(dst => dst.Cars, opt => opt.Ignore());
                cfg.CreateMap<CarDto, Car>()
                    .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Brand));
            }).CreateMapper();
            await _database.Cars.CreateAsync(mapper.Map<CarDto, Car>(carDto));
            await _database.SaveAsync();
        }

        public async Task EditAsync(CarDto carDto)
        {
            Car car = await _database.Cars.GetAsync(carDto.Id);
            if (car == null)
            {
                throw new RentCarValidationException(String.Empty, "Car is not found");
            }
            var mapper = new MapperConfiguration( cfg => 
            {
                cfg.CreateMap<BrandDto, Brand>()
                    .ForMember(dst => dst.Cars, opt => opt.Ignore());
                cfg.CreateMap<CarDto, Car>()
                    .ForMember(dst => dst.Brand, opt => opt.MapFrom(src => src.Brand));
            }).CreateMapper();
            car = mapper.Map<CarDto, Car>(carDto);
            _database.Cars.Update(car);
            await _database.SaveAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id != null)
            {
                _database.Cars.Delete(id.Value);
                await _database.SaveAsync();
            }
        }

        public void Dispoce()
        {
            _database.Dispose();
        }
    }
}
