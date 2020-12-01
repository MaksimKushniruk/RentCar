using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICarService
    {
        Car CreateCar(Dictionary<string, string> fields);
        bool DeleteCar(int id);
        List<Car> GetCar(Dictionary<string, string> fields);
        Car UpdateCar(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
