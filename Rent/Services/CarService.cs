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
            int success = CarRepository.AddCar(new Car(modelName, brandName, color, year, dailyPrice));
            if (success > 0)
                return "Успешно добавлено";
            else
                throw new Exception("Ошибка добавления данных.");
        }
        // Принимаем Id удаляемого автомобиля, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public string DeleteCar(int id)
        {
            int success = CarRepository.DeleteCar(id);
            if (success > 0)
                return "Успешно удалено";
            else
                throw new Exception("Ошибка удаления данных.");
        }
        // Принимаем Id искомого автомобиля, передаем в репозиторий для поиска, проверяем успешность через возвращаемый результат.
        public Car GetCar(int id)
        {
            Car car = CarRepository.GetCar(id);
            if (car != null)
                return car;
            else
                throw new Exception("Не удалось найти объект.");
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Car> GetCar()
        {
            List<Car> cars = new List<Car>();
            DataTable dataTable = CarRepository.GetCar();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                cars.Add(new Car((int)dataRow.ItemArray[0], (string)dataRow.ItemArray[1], (string)dataRow.ItemArray[2], (string)dataRow.ItemArray[3], (int)dataRow.ItemArray[4], (decimal)dataRow.ItemArray[5]));
            }
            if (cars.Count > 0)
                return cars;
            else
                throw new Exception("Не удалось получить данные.");
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public string UpdateCar(Car car)
        {
            int success = CarRepository.UpdateCar(car);
            if (success > 0)
                return "Успешно изменено";
            else
                throw new Exception("Изменение не удалось");
        }
    }
}
