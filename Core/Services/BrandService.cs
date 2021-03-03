using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;

namespace Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _database;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        // TODO: Use DI for Automapper
        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Brand, BrandDto>()
                    .ForMember(dst => dst.Cars, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(await _database.Brands.GetAllAsync());
        }

        public async Task<BrandDto> GetAsync(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Brand brand = await _database.Brands.GetAsync(id.Value);
            if (brand == null)
            {
                throw new RentCarValidationException(String.Empty, "Brand is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarDto>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
                cfg.CreateMap<Brand, BrandDto>()
                    .ForMember(dst => dst.Cars, src => src.MapFrom(brand => brand.Cars));
            }).CreateMapper();
            return mapper.Map<Brand, BrandDto>(brand);
        }

        public async Task CreateAsync(BrandDto brandDto)
        {
            Brand brand = new Brand
            {
                Title = brandDto.Title
            };
            await _database.Brands.CreateAsync(brand);
            await _database.SaveAsync();
        }

        public async Task EditAsync(BrandDto brandDto)
        {
            Brand brand = await _database.Brands.GetAsync(brandDto.Id);
            if (brand == null)
            {
                throw new RentCarValidationException(String.Empty, "Brand is not found");
            }
            brand.Title = brandDto.Title;
            _database.Brands.Update(brand);
            await _database.SaveAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id != null)
            {
                _database.Brands.Delete(id.Value);
                await _database.SaveAsync();
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
