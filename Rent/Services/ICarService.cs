using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Services
{
    public interface ICarService
    {
        string CreateCar(string modelName, string brandName, string color, int year, decimal dailyPrice);
        string DeleteCar(int id);
        Car GetCar(int id);
        List<Car> GetCar();
        string UpdateCar(int id, string modelName, string brandName, string color, int year, decimal dailyPrice);
    }
}
