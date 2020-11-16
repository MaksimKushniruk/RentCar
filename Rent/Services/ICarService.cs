using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICarService
    {
        int CreateCar(string registrationNumber, string modelName, string brandName, string color, int year, decimal dailyPrice);
        int DeleteCar(int id);
        List<Car> GetCar(Request request);
        int UpdateCar(Car car);
    }
}
