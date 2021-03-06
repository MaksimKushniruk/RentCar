﻿using Rent.Models;
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
        /// <summary>
        /// Reservation service for creating object. Returns Id of created Reservation in database.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public int CreateReservation(Reservation reservation)
        {
            return reservationRepository.AddReservation(reservation);
        }
        /// <summary>
        /// Reservation service for deleting object. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteReservation(int id)
        {
            return reservationRepository.DeleteReservation(id);
        }
        /// <summary>
        /// Reservation search in database service. Returns List of Reservations.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Reservation update service. Returns updated Reservation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        public Reservation UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List <Reservation> reservations = reservationRepository.GetReservation(new ReservationRequest { Id = id });
                reservations.FirstOrDefault().Car.Id = int.Parse(fieldsForUpdate["Car Id"]);
                reservations.FirstOrDefault().Customer.Id = int.Parse(fieldsForUpdate["Customer Id"]);
                reservations.FirstOrDefault().DiscountCoupon.Id = int.Parse(fieldsForUpdate["Discount Coupon Id"]);
                reservations.FirstOrDefault().StartDate = DateTime.Parse(fieldsForUpdate["Start Date"]);
                reservations.FirstOrDefault().FinalDate = string.IsNullOrEmpty(fieldsForUpdate["Final Date"]) ? (DateTime?)null : DateTime.Parse(fieldsForUpdate["Final Date"]);
                reservations.FirstOrDefault().Price = string.IsNullOrEmpty(fieldsForUpdate["Price"]) ? (decimal?)null : decimal.Parse(fieldsForUpdate["Price"]);
                reservationRepository.UpdateReservation(reservations.FirstOrDefault());
            return reservations.FirstOrDefault();
        }
    }
}
