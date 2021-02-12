using System.Collections.Generic;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICarRepository
    {
        /// <summary>
        /// Adding object to database. Returns id of added Car.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int AddCar(Car car);
        /// <summary>
        /// Deleting Car from database. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCar(int id);
        /// <summary>
        /// Searching Car or Cars in database. Returns all found Cars.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<Car> GetCar(CarRequest request);
        /// <summary>
        /// Updating Car in database. Returns bool result of operation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        bool UpdateCar(Car car);
    }
}
