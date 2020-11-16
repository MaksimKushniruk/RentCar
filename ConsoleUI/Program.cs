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

            //int num = carService.CreateCar("a111bb777", "c300", "Chrysler", "Black", 2020, 4000);
            //Console.WriteLine($"{num} добавлено машин");
            List<Car> cars = carService.GetCar(new Request { BrandName = "Mercedes"});
            Console.WriteLine(cars[0].Id);

            Console.ReadKey();
        }
    }
}
