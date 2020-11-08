using System;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICarRepository
    {
        int AddCar(Car car);
        void UpdateCar(int id, string modelName, string brandName, string color, int year, decimal dailyPrice);
        void DeleteCar(Car car);
        void ReadCar(int id);
    }
}
