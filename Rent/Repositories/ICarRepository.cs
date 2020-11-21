using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICarRepository
    {
        int AddCar(Car car);
        bool DeleteCar(int id);
        List<Car> GetCar(CarRequest request);
        bool UpdateCar(Car car);
    }
}
