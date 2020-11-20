using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICarRepository
    {
        bool AddCar(Car car, out int id);
        bool DeleteCar(int id);
        List<Car> GetCar(CarRequest request);
        bool UpdateCar(Car car);
    }
}
