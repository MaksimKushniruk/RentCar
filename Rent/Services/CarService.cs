using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rent.Services
{
    public class CarService : ICarService
    {
        private ICarRepository carRepository { get; }
        public CarService()
        {
            carRepository = new CarRepository();
        }
        /// <summary>
        /// Creating Car. Returns Created object with id from database.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Car CreateCar(Dictionary<string, string> fields)
        {
            int id = carRepository.AddCar(new Car(fields["License plate"], 
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
        /// <summary>
        /// Deleting Car. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCar(int id)
        {
            return carRepository.DeleteCar(id);
        }
        /// <summary>
        /// Searching Car. Returns list with all foun objects.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<Car> GetCar(Dictionary<string, string> fields)
        {
            return carRepository.GetCar(new CarRequest(fields["Id"].ToNullableInt(), 
                                                       fields["License plate"], 
                                                       fields["Model"], 
                                                       fields["Brand"], 
                                                       fields["Color"], 
                                                       fields["Year"].ToNullableInt(), 
                                                       fields["Minimal price"].ToNullableDecimal(), 
                                                       fields["Maximal price"].ToNullableDecimal(), 
                                                       fields["Status"].ToCarRentStatus()));
        }
        /// <summary>
        /// Updating Car. Return updated object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        public Car UpdateCar(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<Car> cars = carRepository.GetCar(new CarRequest { Id = id });
            cars.FirstOrDefault().LicensePlate = fieldsForUpdate["License plate"];
            cars.FirstOrDefault().ModelName = fieldsForUpdate["Model"];
            cars.FirstOrDefault().BrandName = fieldsForUpdate["Brand"];
            cars.FirstOrDefault().Color = fieldsForUpdate["Color"];
            cars.FirstOrDefault().Year = Int32.Parse(fieldsForUpdate["Year"]);
            cars.FirstOrDefault().PricePerHour = decimal.Parse(fieldsForUpdate["Price per hour"]);
            cars.FirstOrDefault().Status = (CarRentStatus)Enum.Parse(typeof(CarRentStatus), fieldsForUpdate["Status"], false);
            carRepository.UpdateCar(cars.FirstOrDefault());
            return cars.FirstOrDefault();
        }
    }
}
