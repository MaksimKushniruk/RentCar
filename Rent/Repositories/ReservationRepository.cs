using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    class ReservationRepository : IReservationRepository
    {
        public int AddReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_AddReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CarId", reservation.Car.Id));
                command.Parameters.Add(new SqlParameter("@CustomerId", reservation.Customer.Id));
                command.Parameters.Add(new SqlParameter("@DiscountCouponId", reservation.DiscountCoupon.Id));
                command.Parameters.Add(new SqlParameter("@StartDate", reservation.StartDate));
                command.Parameters.Add(new SqlParameter("@FinalDate", reservation.FinalDate));
                command.Parameters.Add(new SqlParameter("@Price", reservation.Price));
                return command.ExecuteNonQuery();
            }
        }
        public int DeleteReservation(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                return command.ExecuteNonQuery();
            }
        }
        public List<Reservation> GetReservation(ReservationRequest request)
        {
            List<Reservation> reservations = new List<Reservation>();
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", request.Id));
                command.Parameters.Add(new SqlParameter("@CarId", request.CarId));
                command.Parameters.Add(new SqlParameter("@CustomerId", request.CustomerId));
                command.Parameters.Add(new SqlParameter("@DiscountCouponId", request.DiscountCouponId));
                command.Parameters.Add(new SqlParameter("@StartDate", request.StartDate));
                command.Parameters.Add(new SqlParameter("@FinalDate", request.FinalDate));
                command.Parameters.Add(new SqlParameter("@Price", request.Price));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservations.Add(new Reservation(reader[""].CastDbValue<int>(),
                                                     new Car(reader[""].CastDbValue<int>(),
                                                             reader[""].CastDbValue<string>(),
                                                             reader[""].CastDbValue<string>(),
                                                             reader[""].CastDbValue<string>(),
                                                             reader[""].CastDbValue<string>(),
                                                             reader[""].CastDbValue<int>(),
                                                             reader[""].CastDbValue<decimal>(),
                                                             reader[""].CastDbValue<CarRentStatus>()),
                                                     new Customer(reader[""].CastDbValue<int>(),
                                                                  reader[""].CastDbValue<string>(),
                                                                  reader[""].CastDbValue<string>(),
                                                                  reader[""].CastDbValue<string>(),
                                                                  reader[""].CastDbValue<string>()),
                                                     new DiscountCoupon(reader[""].CastDbValue<int>(),
                                                                        reader[""].CastDbValue<string>(),
                                                                        reader[""].CastDbValue<int>()),
                                                     reader[""].CastDbValue<DateTime>(),
                                                     reader[""].CastDbValue<DateTime>(),
                                                     reader[""].CastDbValue<decimal>()));
                }
            }
            return reservations;
        }
        public int UpdateReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", reservation.Id));
                command.Parameters.Add(new SqlParameter("@CarId", reservation.Car.Id));
                command.Parameters.Add(new SqlParameter("@CustomerId", reservation.Customer.Id));
                command.Parameters.Add(new SqlParameter("@DiscountCouponId", reservation.DiscountCoupon.Id));
                command.Parameters.Add(new SqlParameter("@StartDate", reservation.StartDate));
                command.Parameters.Add(new SqlParameter("@FinalDate", reservation.FinalDate));
                command.Parameters.Add(new SqlParameter("@Price", reservation.Price));
                return command.ExecuteNonQuery();
            }
        }
    }
}
