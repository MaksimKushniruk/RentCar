using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _database;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        // TODO: Use Automapper
        public IEnumerable<BrandDto> GetAll()
        {
            IEnumerable<Brand> brands = _database.Brands.GetAll();
            List<BrandDto> brandDtos = new List<BrandDto>();
            foreach(Brand brand in brands)
            {
                List<CarDto> carDtos = new List<CarDto>();
                foreach(Car car in brand.Cars)
                {
                    carDtos.Add(new CarDto
                    {
                        Id = car.Id,
                        LicensePlate = car.LicensePlate,
                        ModelName = car.ModelName,
                        Color = car.Color,
                        Year = car.Year,
                        PricePerHour = car.PricePerHour,
                        Status = (CarRentStatusDto)car.Status,
                        Brand = new BrandDto { Id = car.Brand.Id}
                    });
                }
                brandDtos.Add(new BrandDto
                {
                    Id = brand.Id,
                    Title = brand.Title,
                    Cars = carDtos
                });
            }
            return brandDtos;
        }

        // TODO: Use Automapper
        public BrandDto Get(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Brand brand = _database.Brands.Get(id.Value);
            if (brand == null)
            {
                throw new RentCarValidationException(String.Empty, "Brand is not found");
            }
            List<CarDto> carDtos = new List<CarDto>();
            foreach (Car car in brand.Cars)
            {
                carDtos.Add(new CarDto
                {
                    Id = car.Id,
                    LicensePlate = car.LicensePlate,
                    ModelName = car.ModelName,
                    Color = car.Color,
                    Year = car.Year,
                    PricePerHour = car.PricePerHour,
                    Status = (CarRentStatusDto)car.Status,
                    Brand = new BrandDto { Id = car.Brand.Id }
                });
            }
            return new BrandDto
            {
                Id = brand.Id,
                Title = brand.Title,
                Cars = carDtos
            };
        }

        public void Create(BrandDto brandDto)
        {
            Brand brand = new Brand
            {
                Title = brandDto.Title
            };
            _database.Brands.Create(brand);
            _database.Save();
        }

        public void Edit(BrandDto brandDto)
        {
            Brand brand = _database.Brands.Get(brandDto.Id);
            if (brand == null)
            {
                throw new RentCarValidationException(String.Empty, "Brand is not found");
            }
            brand.Title = brandDto.Title;
            _database.Brands.Update(brand);
            _database.Save();
        }

        public void Delete(int? id)
        {
            if (id != null)
            {
                _database.Brands.Delete(id.Value);
                _database.Save();
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
