using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return CarRepository.GetCar(new CarRequest(fields["Id"].ToNullableInt(), 
                                                       fields["License plate"], 
                                                       fields["Model"], 
                                                       fields["Brand"], 
                                                       fields["Color"], 
                                                       fields["Year"].ToNullableInt(), 
                                                       fields["Minimal price"].ToNullableDecimal(), 
                                                       fields["Maximal price"].ToNullableDecimal(), 
                                                       fields["Status"].ToCarRentStatus()));
        }
        
        public Car UpdateCar(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<Car> cars = CarRepository.GetCar(new CarRequest { Id = id });
            cars.FirstOrDefault().LicensePlate = fieldsForUpdate["License plate"];
            cars.FirstOrDefault().ModelName = fieldsForUpdate["Model"];
            cars.FirstOrDefault().BrandName = fieldsForUpdate["Brand"];
            cars.FirstOrDefault().Color = fieldsForUpdate["Color"];
            cars.FirstOrDefault().Year = Int32.Parse(fieldsForUpdate["Year"]);
            cars.FirstOrDefault().PricePerHour = decimal.Parse(fieldsForUpdate["Price per hour"]);
            cars.FirstOrDefault().Status = (CarRentStatus)int.Parse(fieldsForUpdate["Status"]);
            CarRepository.UpdateCar(cars.FirstOrDefault());
            return cars.FirstOrDefault();
        }
    }
}
