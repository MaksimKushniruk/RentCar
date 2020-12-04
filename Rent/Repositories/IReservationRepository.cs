using System;
using Rent.Models;
using System.Data;
using System.Collections.Generic;

namespace Rent.Repositories
{
    interface IReservationRepository
    {
        /// <summary>
        /// Adding object to database. Returns id of added reservation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int AddReservation(Reservation reservation);
        /// <summary>
        /// Deleting reservation from database. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteReservation(int id);
        /// <summary>
        /// Searching reservation or reservations in database. Returns all found reservations.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<Reservation> GetReservation(ReservationRequest request);
        /// <summary>
        /// Updating reservation in database. Returns bool result of operation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        bool UpdateReservation(Reservation reservation);
    }
}
