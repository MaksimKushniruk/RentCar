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
        // Принимаем информацию-поля автомобиля, создаем новый объект, передаем в репозиторий для записи, проверяем успешность через возвращаемый результат.
        public int CreateCar(string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            return CarRepository.AddCar(new Car(modelName, brandName, color, year, dailyPrice));
        }
        // Принимаем Id удаляемого автомобиля, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public int DeleteCar(int id)
        {
            return CarRepository.DeleteCar(id);
        }
        // Принимаем Id искомого автомобиля, передаем в репозиторий для поиска, проверяем успешность через возвращаемый результат.
        public Car GetCar(int id)
        {
            return CarRepository.GetCar(id);
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Car> GetCar()
        {
            return CarRepository.GetCar();
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public int UpdateCar(Car car)
        {
            return CarRepository.UpdateCar(car);
        }
    }
}
