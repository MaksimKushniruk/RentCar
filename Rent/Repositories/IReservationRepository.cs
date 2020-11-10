using System;
using Rent.Models;
using System.Data;

namespace Rent.Repositories
{
    interface IReservationRepository
    {
        int AddReservation(Reservation reservation);
        int DeleteReservation(int id);
        Reservation GetReservation(int id);
        DataTable GetReservation();
        int UpdateReservation(Reservation reservation);
    }
}
