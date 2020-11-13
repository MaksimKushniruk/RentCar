using Rent.Models;
using System;
using System.Collections.Generic;
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
            Car car = null;
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.ModelName, c.BrandName, c.Color, c.[Year], c.DailyPrice FROM Cars c WHERE c.Id = {id}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                car = new Car(dataRow["Id"].CastDbValue<int>(),
                              dataRow["ModelName"].CastDbValue<string>(),
                              dataRow["BrandName"].CastDbValue<string>(),
                              dataRow["Color"].CastDbValue<string>(),
                              dataRow["Year"].CastDbValue<int>(),
                              dataRow["DailyPrice"].CastDbValue<decimal>());
            }
            return car;
        }
        // Перегрузка, ищем все автомобили, возвращаем в виде объекта List<Car>.
        public List<Car> GetCar()
        {
            List<Car> cars = new List<Car>();
            DataTable dataTable;
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT c.Id, c.ModelName, c.BrandName, c.Color, c.[Year], c.DailyPrice FROM Cars c", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach(DataRow dataRow in dataTable.Rows)
            {
                cars.Add(new Car(dataRow["Id"].CastDbValue<int>(),
                                 dataRow["ModelName"].CastDbValue<string>(),
                                 dataRow["BrandName"].CastDbValue<string>(),
                                 dataRow["Color"].CastDbValue<string>(),
                                 dataRow["Year"].CastDbValue<int>(),
                                 dataRow["DailyPrice"].CastDbValue<decimal>()));
            }
            return cars;
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
