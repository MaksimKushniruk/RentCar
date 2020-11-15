using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    public class CarRepository : ICarRepository
    {
        public int AddCar(Car car)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Cars (RegistrationNumber, ModelName, BrandName, Color, [Year], DailyPrice) VALUES ('{car.RegistrationNumber}', '{car.ModelName}', '{car.BrandName}', '{car.Color}', {car.Year}, {car.DailyPrice})", connection);
                return command.ExecuteNonQuery();
            }
        }
        public int DeleteCar(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Cars WHERE id = {id}", connection);
                return command.ExecuteNonQuery();
            }
        }
        public Car GetCar(int id)
        {
            Car car = null;
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.RegistrationNumber, c.ModelName, c.BrandName, c.Color, c.[Year], c.DailyPrice FROM Cars c WHERE c.Id = {id}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                car = new Car(dataRow["Id"].CastDbValue<int>(),
                              dataRow["RegistrationNumber"].CastDbValue<string>(),
                              dataRow["ModelName"].CastDbValue<string>(),
                              dataRow["BrandName"].CastDbValue<string>(),
                              dataRow["Color"].CastDbValue<string>(),
                              dataRow["Year"].CastDbValue<int>(),
                              dataRow["DailyPrice"].CastDbValue<decimal>());
            }
            return car;
        }
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
                                 dataRow["RegistrationNumber"].CastDbValue<string>(),
                                 dataRow["ModelName"].CastDbValue<string>(),
                                 dataRow["BrandName"].CastDbValue<string>(),
                                 dataRow["Color"].CastDbValue<string>(),
                                 dataRow["Year"].CastDbValue<int>(),
                                 dataRow["DailyPrice"].CastDbValue<decimal>()));
            }
            return cars;
        }
        public int UpdateCar(Car car)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Cars SET RegistrationNumber = {car.RegistrationNumber}, ModelName = {car.ModelName}, BrandName = {car.BrandName}, Color = {car.Color}, [Year] = {car.Year}, DailyPrice = {car.DailyPrice} WHERE Cars.Id = {car.Id}", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
