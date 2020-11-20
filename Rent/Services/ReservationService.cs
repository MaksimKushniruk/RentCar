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
        public bool CreateReservation(out int reservationId, Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal price)
        {
            bool result =  ReservationRepository.AddReservation(new Reservation(car, customer, discountCoupon, startDate, finalDate, price), out int id);
            reservationId = id;
            return result;
        }
        public bool DeleteReservation(int id)
        {
            return ReservationRepository.DeleteReservation(id);
        }
        public List<Reservation> GetReservation(ReservationRequest request)
        {
            return ReservationRepository.GetReservation(request);
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
