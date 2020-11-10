using Rent.Models;
using System;
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
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Reservations WHERE id = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                Reservation reservation = null;
                if (reader.HasRows)
                    reservation = new Reservation(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetDecimal(5));
                reader.Close();
                return reservation;
            }
        }
        // Перегрузка, ищем все резервирования, возвращаем в виде объекта DataTable.
        public DataTable GetReservation()
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Reservations", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
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
