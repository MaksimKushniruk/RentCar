using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    class ReservationRepository : IReservationRepository
    {
        /// <summary>
        /// Adding object to database. Returns id of added reservation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public int AddReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_AddReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@CarId", reservation.Car.Id));
                command.Parameters.Add(new SqlParameter("@CustomerId", reservation.Customer.Id));
                command.Parameters.Add(new SqlParameter("@DiscountCouponId", reservation.DiscountCoupon.Id));
                command.Parameters.Add(new SqlParameter("@StartDate", reservation.StartDate));
                command.Parameters.Add(new SqlParameter("@FinalDate", reservation.FinalDate));
                command.Parameters.Add(new SqlParameter("@Price", reservation.Price));
                command.ExecuteNonQuery();
                // Возвращаем Id созданного объекта
                return command.Parameters["@Id"].Value.CastDbValue<int>();
            }
        }
        /// <summary>
        /// Deleting reservation from database. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteReservation(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Searching reservation or reservations in database. Returns all found reservations.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                command.Parameters.Add(new SqlParameter("@MinDate", request.MinDate));
                command.Parameters.Add(new SqlParameter("@MaxDate", request.MaxDate));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservations.Add(new Reservation(reader["ReservationId"].CastDbValue<int>(),
                                                     new Car(reader["CarId"].CastDbValue<int>(),
                                                             reader["RegistrationNumber"].CastDbValue<string>(),
                                                             reader["ModelName"].CastDbValue<string>(),
                                                             reader["BrandName"].CastDbValue<string>(),
                                                             reader["Color"].CastDbValue<string>(),
                                                             reader["Year"].CastDbValue<int>(),
                                                             reader["PricePerHour"].CastDbValue<decimal>(),
                                                             reader["RentStatus"].CastDbValue<CarRentStatus>()),
                                                     new Customer(reader["CustomerId"].CastDbValue<int>(),
                                                                  reader["FirstName"].CastDbValue<string>(),
                                                                  reader["LastName"].CastDbValue<string>(),
                                                                  reader["City"].CastDbValue<string>(),
                                                                  reader["PhoneNumber"].CastDbValue<string>()),
                                                     new DiscountCoupon(reader["DiscountCouponId"].CastDbValue<int>(),
                                                                        reader["Coupon"].CastDbValue<string>(),
                                                                        reader["Discount"].CastDbValue<int>()),
                                                     reader["StartDate"].CastDbValue<DateTime>(),
                                                     reader["FinalDate"].CastDbValue<DateTime>(),
                                                     reader["Price"].CastDbValue<decimal>()));
                }
                reader.Close();
            }
            return reservations;
        }
        /// <summary>
        /// Updating reservation in database. Returns bool result of operation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool UpdateReservation(Reservation reservation)
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
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
