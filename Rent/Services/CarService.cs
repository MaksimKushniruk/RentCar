using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rent.Services
{
    public class CarService : ICarService
    {
        public string CreateCar(string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            ICarRepository carRepository = new CarRepository();
            int success = carRepository.AddCar(new Car(modelName, brandName, color, year, dailyPrice));
            if (success > 0)
                return "Успешно добавлено";
            else
                throw new Exception("Ошибка добавления данных.");
        }

        public string DeleteCar(int id)
        {
            ICarRepository carRepository = new CarRepository();
            int success = carRepository.DeleteCar(id);
            if (success > 0)
                return "Успешно удалено";
            else
                throw new Exception("Ошибка удаления данных.");
        }

        public Car GetCar(int id)
        {
            ICarRepository carRepository = new CarRepository();
            Car car = carRepository.GetCar(id);
            if (car != null)
                return car;
            else
                throw new Exception("Не удалось найти объект.");
        }
        // Конвертируем DataTable в List<Car>. Поискать другие способы приведения
        public List<Car> GetCar()
        {
            ICarRepository carRepository = new CarRepository();
            List<Car> cars = new List<Car>();
            DataTable dataTable = carRepository.GetCar();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                cars.Add(new Car((int)dataRow.ItemArray[0], (string)dataRow.ItemArray[1], (string)dataRow.ItemArray[2], (string)dataRow.ItemArray[3], (int)dataRow.ItemArray[4], (decimal)dataRow.ItemArray[5]));
            }
            if (cars.Count > 0)
                return cars;
            else
                throw new Exception("Не удалось получить данные.");
        }
        // Много If'ов, решение?
        public string UpdateCar(int id, string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            ICarRepository carRepository = new CarRepository();
            Car car = carRepository.GetCar(id);
            if (modelName != "")
                car.ModelName = modelName;
            if (brandName != "")
                car.BrandName = brandName;
            if (color != "")
                car.Color = color;
            if (year != 0)
                car.Year = year;
            if (dailyPrice != 0)
                car.DailyPrice = dailyPrice;
            int success = carRepository.UpdateCar(car);
            if (success > 0)
                return "Успешно изменено";
            else
                throw new Exception("Изменение не удалось");
        }
    }
}
