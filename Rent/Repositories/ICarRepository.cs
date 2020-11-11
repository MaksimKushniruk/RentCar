using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICarRepository
    {
        int AddCar(Car car);
        int DeleteCar(int id);
        Car GetCar(int id);
        public List<Car> GetCar();
        int UpdateCar(Car car);
    }
}
