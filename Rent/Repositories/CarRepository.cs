using Rent.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    public class CarRepository : ICarRepository
    {
        // Добавляем автомобиль и возвращаем количество изммененных записей.
        public int AddCar(Car car)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Cars (ModelName, BrandName, Color, [Year], DailyPrice) VALUES ('{car.ModelName}', '{car.BrandName}', '{car.Color}', {car.Year}, {car.DailyPrice})", connection);
                return command.ExecuteNonQuery();
            }
        }
        // Удаляем автомобиль и возвращаем количество измененных записей.
        public int DeleteCar(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Cars WHERE id = {id}", connection);
                return command.ExecuteNonQuery();
            }
        }
        // Ищем автомобиль по Id, возвращаем объект Car.
        public Car GetCar(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Cars WHERE id = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                Car car = null;
                if (reader.HasRows)
                    car = new Car(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetDecimal(5));
                reader.Close();
                return car;
            }
        }
        // Перегрузка, ищем все автомобили, возвращаем в виде объекта DataTable.
        public DataTable GetCar()
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cars", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
        // Принимаем объект Car, обновляем его в БД, возвращаем количество измененных записей.
        public int UpdateCar(Car car)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Cars SET ModelName = {car.ModelName}, BrandName = {car.BrandName}, Color = {car.Color}, [Year] = {car.Year}, DailyPrice = {car.DailyPrice} WHERE Cars.Id = {car.Id}", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
