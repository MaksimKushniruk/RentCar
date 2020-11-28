using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;
using System.Text;

namespace ConsoleUI
{
    public static class Vehicle
    {

        public static Car GetVehicle()
        {
            ICarService carService = new CarService();
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Logo("Введите данные");
                List<string> keys = new List<string> { "Id", "Гос. Номер", "Модель", "Бренд", "Цвет", "Год", "Минимальная цена", "Максимальная цена" };
                Dictionary<string, string> fields = ConsoleMenu.InputData(keys);
                int? id = string.IsNullOrEmpty(fields["Id"]) ? (int?)null : Int32.Parse(fields["Id"]);
                int? year = string.IsNullOrEmpty(fields["Год"]) ? (int?)null : Int32.Parse(fields["Год"]);
                decimal? minPrice = string.IsNullOrEmpty(fields["Минимальная цена"]) ? (decimal?)null : Int32.Parse(fields["Минимальная цена"]);
                decimal? maxPrice = string.IsNullOrEmpty(fields["Максимальная цена"]) ? (decimal?)null : Int32.Parse(fields["Максимальная цена"]);
                CarRequest request = new CarRequest(id, fields["Гос. Номер"], fields["Модель"], fields["Бренд"], fields["Цвет"], year, minPrice, maxPrice);
                List<Car> cars = carService.GetCar(request);
                Dictionary<string, string> car = new Dictionary<string, string>();
                ConsoleMenu.MainMenu(new List<string> { "Найти", "Отменить" });
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Clear();
                        ConsoleMenu.Logo("Введите Id автомобиля");
                        ConsoleMenu.Print<Car>(cars);
                        cars = carService.GetCar(new CarRequest { Id = Int32.Parse(Console.ReadLine()) });
                        car.Add("Id", cars[0].Id.ToString());
                        car.Add("Гос. Номер", cars[0].RegistrationNumber);
                        car.Add("Модель", cars[0].ModelName);
                        car.Add("Бренд", cars[0].BrandName);
                        car.Add("Цвет", cars[0].Color);
                        car.Add("Год", cars[0].Year.ToString());
                        car.Add("Цена", cars[0].PricePerHour.ToString());
                        Console.Clear();
                        ConsoleMenu.Logo("Хотите выбрать текущий автомобиль?");
                        ConsoleMenu.Menu(car);
                        ConsoleMenu.MainMenu(new List<string> { "Да", "Нет", "Назад" });
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                return cars[0];
                            case '2':
                                continue;
                            case '3':
                                return null;
                            default:
                                continue;
                        }
                    case '2':
                        return null;
                    default:
                        continue;
                }
            }
        }
    }
}
