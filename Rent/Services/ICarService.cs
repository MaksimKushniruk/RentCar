using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Services
{
    public interface ICarService
    {
        void CreateCar(string modelName, string brandName, string color, int year, decimal dailyPrice);
        void UpdateCar(int id);
        void DeleteCar(int id);
        Car GetCar(int id);

        List<Car> GetCar();
        
    }
}
