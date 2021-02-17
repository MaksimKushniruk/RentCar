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
                        BrandId = brand.Id
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
                throw new RentCarValidationException(String.Empty, "Brand is don't found");
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
                    BrandId = brand.Id
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
                throw new RentCarValidationException(String.Empty, "Brand is dont Found");
            }
            brand.Title = brandDto.Title;
            brand.Cars.Clear();
            foreach (CarDto carDto in brandDto.Cars)
            {
                brand.Cars.Add(new Car
                {
                    Id = carDto.Id,
                    LicensePlate = carDto.LicensePlate,
                    ModelName = carDto.ModelName,
                    Color = carDto.Color,
                    Year = carDto.Year,
                    PricePerHour = carDto.PricePerHour,
                    Status = (CarRentStatus)carDto.Status,
                    BrandId = brand.Id
                });
            }
            _database.Brands.Update(brand);
        }

        public void Delete(int? id)
        {
            if (id != null)
            {
                _database.Brands.Delete(id.Value);
            }
        }

        public void Dispoce()
        {
            _database.Dispose();
        }
    }
}
