using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IReservationService
    {
        /// <summary>
        /// Creating Reservation. Returns Id of created reservation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int CreateReservation(Reservation reservation);
        /// <summary>
        /// Deleting Reservation from database. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteReservation(int id);
        /// <summary>
        /// Serching Reservations. Returns List<Reservation> with all found reservations
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        List<Reservation> GetReservation(Dictionary<string, string> fields);
        /// <summary>
        /// Updating Reservation. Returns updated reservation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        Reservation UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
