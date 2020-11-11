using System;
using Rent.Models;
using System.Data;
using System.Collections.Generic;

namespace Rent.Repositories
{
    interface IReservationRepository
    {
        int AddReservation(Reservation reservation);
        int DeleteReservation(int id);
        Reservation GetReservation(int id);
        List<Reservation> GetReservation();
        int UpdateReservation(Reservation reservation);
    }
}
