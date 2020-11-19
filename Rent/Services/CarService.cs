using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rent.Services
{
    public class CarService : ICarService
    {
        private ICarRepository CarRepository { get; }
        public CarService()
        {
            CarRepository = new CarRepository();
        }
        public int CreateCar(string registrationNumber, string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            return CarRepository.AddCar(new Car(registrationNumber, modelName, brandName, color, year, dailyPrice));
        }
        public int DeleteCar(int id)
        {
            return CarRepository.DeleteCar(id);
        }
        public List<Car> GetCar(CarRequest request)
        {
            return CarRepository.GetCar(request);
        }
        public int UpdateCar(int id, Dictionary<string, string> fieldsForUpdate)
        {
            Car cars = CarRepository.GetCar(new CarRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("RegistrationNumber"))
            {
                cars.RegistrationNumber = fieldsForUpdate["RegistrationNumber"];
            }
            if (fieldsForUpdate.ContainsKey("ModelName"))
            {
                cars.ModelName = fieldsForUpdate["ModelName"];
            }
            if (fieldsForUpdate.ContainsKey("BrandName"))
            {
                cars.BrandName = fieldsForUpdate["BrandName"];
            }
            if (fieldsForUpdate.ContainsKey("Color"))
            {
                cars.Color = fieldsForUpdate["Color"];
            }
            if (fieldsForUpdate.ContainsKey("Year"))
            {
                cars.Year = int.Parse(fieldsForUpdate["Year"]);
            }
            if (fieldsForUpdate.ContainsKey("DailyPrice"))
            {
                cars.DailyPrice = decimal.Parse(fieldsForUpdate["DailyPrice"]);
            }
            if (fieldsForUpdate.ContainsKey("Status"))
            {
                cars.Status = (CarRentStatus)int.Parse(fieldsForUpdate["Status"]);
            }


            return CarRepository.UpdateCar(cars);
        }
    }
}
