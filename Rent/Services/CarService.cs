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
        public int CreateCar(string registrationNumber, string modelName, string brandName, string color, int year, decimal pricePerHour)
        {
            return CarRepository.AddCar(new Car(registrationNumber, modelName, brandName, color, year, pricePerHour));
        }
        public bool DeleteCar(int id)
        {
            return CarRepository.DeleteCar(id);
        }
        public List<Car> GetCar(CarRequest request)
        {
            return CarRepository.GetCar(request);
        }
        
        public bool UpdateCar(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<Car> cars = CarRepository.GetCar(new CarRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("RegistrationNumber"))
            {
                cars[0].RegistrationNumber = fieldsForUpdate["RegistrationNumber"];
            }
            if (fieldsForUpdate.ContainsKey("ModelName"))
            {
                cars[0].ModelName = fieldsForUpdate["ModelName"];
            }
            if (fieldsForUpdate.ContainsKey("BrandName"))
            {
                cars[0].BrandName = fieldsForUpdate["BrandName"];
            }
            if (fieldsForUpdate.ContainsKey("Color"))
            {
                cars[0].Color = fieldsForUpdate["Color"];
            }
            if (fieldsForUpdate.ContainsKey("Year"))
            {
                cars[0].Year = int.Parse(fieldsForUpdate["Year"]);
            }
            if (fieldsForUpdate.ContainsKey("PricePerHour"))
            {
                cars[0].PricePerHour = decimal.Parse(fieldsForUpdate["PricePerHour"]);
            }
            if (fieldsForUpdate.ContainsKey("Status"))
            {
                cars[0].Status = (CarRentStatus)int.Parse(fieldsForUpdate["Status"]);
            }

            return CarRepository.UpdateCar(cars[0]);
        }
    }
}
