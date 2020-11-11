using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    class ReservationRepository : IReservationRepository
    {
        // Добавляем резервирование и возвращаем количество изммененных записей.
        public int AddReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Reservations (CarId, CustomerId, StartDate, FinalDate, Price) VALUES ({reservation.Car.Id}, {reservation.Customer.Id}, {reservation.StartDate}, {reservation.FinalDate}, {reservation.Price})", connection);
                return command.ExecuteNonQuery();
            }
        }
        // Удаляем резервирование и возвращаем количество измененных записей.
        public int DeleteReservation(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Reservations WHERE id = {id}", connection);
                return command.ExecuteNonQuery();
            }
        }
        // Ищем резервирование по Id, возвращаем объект Reservation.
        public Reservation GetReservation(int id)
        {
            DataTable dataTable;
            Reservation reservation = null;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT r.Id ReservationId, r.StartDate, r.FinalDate, r.Price, ca.Id CarId, ca.ModelName, ca.BrandName, ca.Color, ca.[Year], ca.DailyPrice, cu.Id CustomerId, cu.FirstName, cu.LastName, cu.PhoneNumber FROM Reservations r, Customers cu, Cars ca WHERE r.Id = {id} AND cu.Id = r.CustomerId AND ca.Id = r.CarId", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                reservation = new Reservation(dataRow["ReservationId"].CastDbValue<int>(),
                                              new Car(dataRow["CarId"].CastDbValue<int>(),
                                                      dataRow["ModelName"].CastDbValue<string>(),
                                                      dataRow["BrandName"].CastDbValue<string>(),
                                                      dataRow["Color"].CastDbValue<string>(),
                                                      dataRow["Year"].CastDbValue<int>(),
                                                      dataRow["DailyPrice"].CastDbValue<decimal>()),
                                              new Customer(dataRow["CustomerId"].CastDbValue<int>(),
                                                           dataRow["FirstName"].CastDbValue<string>(),
                                                           dataRow["LastName"].CastDbValue<string>(),
                                                           dataRow["PhoneNumber"].CastDbValue<string>()),
                                              dataRow["StartDate"].CastDbValue<DateTime>(),
                                              dataRow["FinalDate"].CastDbValue<DateTime>(),
                                              dataRow["Price"].CastDbValue<decimal>());
            }
            return reservation;
        }
        // Перегрузка, ищем все резервирования, возвращаем в виде объекта List<Reservation>.
        public List<Reservation> GetReservation()
        {
            List<Reservation> reservations = new List<Reservation>();
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT r.Id ReservationId, r.StartDate, r.FinalDate, r.Price, ca.Id CarId, ca.ModelName, ca.BrandName, ca.Color, ca.[Year], ca.DailyPrice, cu.Id CustomerId, cu.FirstName, cu.LastName, cu.PhoneNumber FROM Reservations r, Customers cu, Cars ca WHERE cu.Id = r.CustomerId AND ca.Id = r.CarId", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                reservations.Add(new Reservation(dataRow["ReservationId"].CastDbValue<int>(), 
                                                 new Car(dataRow["CarId"].CastDbValue<int>(),
                                                         dataRow["ModelName"].CastDbValue<string>(),
                                                         dataRow["BrandName"].CastDbValue<string>(),
                                                         dataRow["Color"].CastDbValue<string>(),
                                                         dataRow["Year"].CastDbValue<int>(),
                                                         dataRow["DailyPrice"].CastDbValue<decimal>()),
                                                 new Customer(dataRow["CustomerId"].CastDbValue<int>(),
                                                              dataRow["FirstName"].CastDbValue<string>(),
                                                              dataRow["LastName"].CastDbValue<string>(),
                                                              dataRow["PhoneNumber"].CastDbValue<string>()),
                                                 dataRow["StartDate"].CastDbValue<DateTime>(),
                                                 dataRow["FinalDate"].CastDbValue<DateTime>(),
                                                 dataRow["Price"].CastDbValue<decimal>()));
            }
            return reservations;
        }
        // Принимаем объект Reservation, обновляем его в БД, возвращаем количество измененных записей.
        public int UpdateReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Reservations SET CarId = {reservation.Car.Id}, CustomerId = {reservation.Customer.Id}, StartDate = {reservation.StartDate},  FinalDate = {reservation.FinalDate}, Price = {reservation.Price} WHERE Reservations.Id = {reservation.Id}", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
