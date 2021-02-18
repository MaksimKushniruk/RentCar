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
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _database;
        public CarService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        // TODO: Use Automapper
        public IEnumerable<CarDto> GetAll()
        {
            IEnumerable<Car> cars = _database.Cars.GetAll();
            List<CarDto> carDtos = new List<CarDto>();
            foreach (Car car in cars)
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
                    BrandId = car.Brand.Id
                });
            }
            return carDtos;
        }

        public CarDto Get(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Car car = _database.Cars.Get(id.Value);
            if (car == null)
            {
                throw new RentCarValidationException(String.Empty, "Car is don't found");
            }
            return new CarDto
            {
                Id = car.Id,
                LicensePlate = car.LicensePlate,
                ModelName = car.ModelName,
                Color = car.Color,
                Year = car.Year,
                PricePerHour = car.PricePerHour,
                Status = (CarRentStatusDto)car.Status,
                BrandId = car.Brand.Id
            };
        }
        
        public void Create(CarDto carDto)
        {
            Car car = new Car
            {
                Id = carDto.Id,
                LicensePlate = carDto.LicensePlate,
                ModelName = carDto.ModelName,
                Color = carDto.Color,
                Year = carDto.Year,
                PricePerHour = carDto.PricePerHour,
                Status = (CarRentStatus)carDto.Status,
                BrandId = carDto.BrandId,
                Brand = new Brand { Id = carDto.BrandId }

            };
            _database.Cars.Create(car);
            _database.Save();
        }

        public void Edit(CarDto carDto)
        {
            Car car = _database.Cars.Get(carDto.Id);
            if (car == null)
            {
                throw new RentCarValidationException(String.Empty, "Car is dont Found");
            }
            car.Id = carDto.Id;
            car.LicensePlate = carDto.LicensePlate;
            car.ModelName = carDto.ModelName;
            car.Color = carDto.Color;
            car.Year = carDto.Year;
            car.PricePerHour = carDto.PricePerHour;
            car.Status = (CarRentStatus)carDto.Status;
            car.BrandId = carDto.BrandId;
            // TODO: Check saved data
            car.Brand = new Brand { Id = carDto.BrandId };
            _database.Cars.Update(car);
            _database.Save();
        }

        public void Delete(int? id)
        {
            if (id != null)
            {
                _database.Cars.Delete(id.Value);
                _database.Save();
            }
        }

        public void Dispoce()
        {
            _database.Dispose();
        }
    }
}
