using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICarService
    {
        bool CreateCar(out int carId, string registrationNumber, string modelName, string brandName, string color, int year, decimal dailyPrice);
        int DeleteCar(int id);
        List<Car> GetCar(CarRequest request);
        int UpdateCar(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
