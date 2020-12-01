using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rent.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository ReservationRepository { get; }
        public ReservationService()
        {
            ReservationRepository = new ReservationRepository();
        }
        public int CreateReservation(Reservation reservation)
        {
            return ReservationRepository.AddReservation(reservation);
        }
        public bool DeleteReservation(int id)
        {
            return ReservationRepository.DeleteReservation(id);
        }
        public List<Reservation> GetReservation(Dictionary<string, string> fields)
        {
            return ReservationRepository.GetReservation(new ReservationRequest(
                    fields["Id"].ToNullableInt(),
                    fields["Car Id"].ToNullableInt(),
                    fields["Customer Id"].ToNullableInt(),
                    fields["DiscountCoupon Id"].ToNullableInt(),
                    DateTime.Parse(fields["MinDate"]),
                    DateTime.Parse(fields["MaxDate"])));
        }
        public bool UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<Reservation> reservations = ReservationRepository.GetReservation(new ReservationRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("CarId"))
            {
                reservations[0].Car.Id = int.Parse(fieldsForUpdate["CarId"]);
            }
            if (fieldsForUpdate.ContainsKey("CustomerId"))
            {
                reservations[0].Customer.Id = int.Parse(fieldsForUpdate["CustomerId"]);
            }
            if (fieldsForUpdate.ContainsKey("DiscountCouponId"))
            {
                reservations[0].DiscountCoupon.Id = int.Parse(fieldsForUpdate["DiscountCouponId"]);
            }
            if (fieldsForUpdate.ContainsKey("StartDate"))
            {
                reservations[0].StartDate = DateTime.Parse(fieldsForUpdate["StartDate"]);
            }
            if (fieldsForUpdate.ContainsKey("FinalDate"))
            {
                reservations[0].FinalDate = DateTime.Parse(fieldsForUpdate["FinalDate"]);
            }
            if (fieldsForUpdate.ContainsKey("Price"))
            {
                reservations[0].Price = decimal.Parse(fieldsForUpdate["Price"]);
            }
            return ReservationRepository.UpdateReservation(reservations[0]);
        }
    }
}
