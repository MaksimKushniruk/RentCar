using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            ICarService carService = new CarService();

            //int num = carService.CreateCar("H777HH777", "s600", "Mercedes-Benz", "Black", 2020, 10000);
            //Console.WriteLine($"{num} добавлено машин");
            List<Car> cars = carService.GetCar(new Request { Status = Rent.CarRentStatus.Свободен });
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Id}\t{car.ModelName}\t{car.BrandName}\t{car.Color}\t{car.Year}\t{car.DailyPrice}");
            }

            Console.ReadKey();
        }
    }
}
