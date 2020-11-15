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
        public Car GetCar(int id)
        {
            return CarRepository.GetCar(id);
        }
        public List<Car> GetCar()
        {
            return CarRepository.GetCar();
        }
        public int UpdateCar(Car car)
        {
            return CarRepository.UpdateCar(car);
        }
    }
}
