using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICarService
    {
        /// <summary>
        /// Creating Car. Returns Created object with id from database.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        Car CreateCar(Dictionary<string, string> fields);
        /// <summary>
        /// Deleting Car. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCar(int id);
        /// <summary>
        /// Searching Car. Returns list with all foun objects.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        List<Car> GetCar(Dictionary<string, string> fields);
        /// <summary>
        /// Updating Car. Return updated object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        Car UpdateCar(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
