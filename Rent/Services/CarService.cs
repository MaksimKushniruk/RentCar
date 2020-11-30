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
        public Car CreateCar(Dictionary<string, string> fields)
        {
            int id = CarRepository.AddCar(new Car(fields["License plate"], 
                                                  fields["Model"], 
                                                  fields["Brand"], 
                                                  fields["Color"], 
                                                  Int32.Parse(fields["Year"]), 
                                                  decimal.Parse(fields["Price"])));
            return new Car(id,
                           fields["License plate"],
                           fields["Model"],
                           fields["Brand"],
                           fields["Color"],
                           Int32.Parse(fields["Year"]),
                           decimal.Parse(fields["Price"]));
        }
        public bool DeleteCar(int id)
        {
            return CarRepository.DeleteCar(id);
        }
        public List<Car> GetCar(Dictionary<string, string> fields)
        {
            return CarRepository.GetCar(new CarRequest(Int32.Parse(fields["Id"]), 
                                                       fields["License plate"], 
                                                       fields["Model"], 
                                                       fields["Brand"], 
                                                       fields["Color"], 
                                                       Int32.Parse(fields["Year"]), 
                                                       decimal.Parse(fields["Minimal price"]), 
                                                       decimal.Parse(fields["Maximal price"]), 
                                                       (CarRentStatus)Enum.Parse(typeof(CarRentStatus), fields["Status"], false)));
        }
        
        public bool UpdateCar(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<Car> cars = CarRepository.GetCar(new CarRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("RegistrationNumber"))
            {
                cars[0].LicensePlate = fieldsForUpdate["RegistrationNumber"];
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
