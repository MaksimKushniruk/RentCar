using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rent.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository reservationRepository { get; }
        public ReservationService()
        {
            reservationRepository = new ReservationRepository();
        }
        public int CreateReservation(Reservation reservation)
        {
            return reservationRepository.AddReservation(reservation);
        }
        public bool DeleteReservation(int id)
        {
            return reservationRepository.DeleteReservation(id);
        }
        public List<Reservation> GetReservation(Dictionary<string, string> fields)
        {
            return reservationRepository.GetReservation(new ReservationRequest(
                    fields["Id"].ToNullableInt(),
                    fields["Car Id"].ToNullableInt(),
                    fields["Customer Id"].ToNullableInt(),
                    fields["Discount Coupon Id"].ToNullableInt(),
                    string.IsNullOrEmpty(fields["MinDate"]) ? (DateTime?)null : DateTime.Parse(fields["MinDate"]),
                    string.IsNullOrEmpty(fields["MaxDate"]) ? (DateTime?)null : DateTime.Parse(fields["MaxDate"])));
        }
        public Reservation UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<Reservation> reservations = reservationRepository.GetReservation(new ReservationRequest { Id = id });
                reservations.FirstOrDefault().Car.Id = int.Parse(fieldsForUpdate["Car Id"]);
                reservations.FirstOrDefault().Customer.Id = int.Parse(fieldsForUpdate["Customer Id"]);
                reservations.FirstOrDefault().DiscountCoupon.Id = int.Parse(fieldsForUpdate["Discount Coupon Id"]);
                reservations.FirstOrDefault().StartDate = DateTime.Parse(fieldsForUpdate["Start Date"]);
                reservations.FirstOrDefault().FinalDate = DateTime.Parse(fieldsForUpdate["Final Date"]);
                reservations.FirstOrDefault().Price = decimal.Parse(fieldsForUpdate["Price"]);
            reservationRepository.UpdateReservation(reservations.FirstOrDefault());
            return reservations.FirstOrDefault();
        }
    }
}
