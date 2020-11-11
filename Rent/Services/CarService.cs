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
        public string CreateCar(string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            CarRepository.AddCar(new Car(modelName, brandName, color, year, dailyPrice));
            return "Успешно добавлено";
        }
        // Принимаем Id удаляемого автомобиля, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public string DeleteCar(int id)
        {
            CarRepository.DeleteCar(id);
            return "Успешно удалено";
        }
        // Принимаем Id искомого автомобиля, передаем в репозиторий для поиска, проверяем успешность через возвращаемый результат.
        public Car GetCar(int id)
        {
            Car car = CarRepository.GetCar(id);
            return car;
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Car> GetCar()
        {
            List<Car> cars = CarRepository.GetCar();
            return cars;
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public string UpdateCar(Car car)
        {
            CarRepository.UpdateCar(car);
            return "Успешно изменено";
        }
    }
}
