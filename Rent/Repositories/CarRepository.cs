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
                SqlCommand command = new SqlCommand($"INSERT INTO Cars (RegistrationNumber, ModelName, BrandName, Color, [Year], DailyPrice, RentStatus) VALUES ('{car.RegistrationNumber}', '{car.ModelName}', '{car.BrandName}', '{car.Color}', {car.Year}, {car.DailyPrice}, {(int)car.Status})", connection);
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

        public List<Car> GetCar(Request request)
        {
            List<Car> cars = new List<Car>();
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetCars", connection);            
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", request.Id));
                command.Parameters.Add(new SqlParameter("@RegistrationNumber", request.RegistrationNumber));
                command.Parameters.Add(new SqlParameter("@ModelName", request.ModelName));
                command.Parameters.Add(new SqlParameter("@BrandName", request.BrandName));
                command.Parameters.Add(new SqlParameter("@Color", request.Color));
                command.Parameters.Add(new SqlParameter("@Year", request.Year));
                command.Parameters.Add(new SqlParameter("@MinPrice", request.MinPrice));
                command.Parameters.Add(new SqlParameter("@MaxPrice", request.MaxPrice));
                command.Parameters.Add(new SqlParameter("@RentStatus", request.Status));

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cars.Add(new Car(dataRow["Id"].CastDbValue<int>(),
                                 dataRow["RegistrationNumber"].CastDbValue<string>(),
                                 dataRow["ModelName"].CastDbValue<string>(),
                                 dataRow["BrandName"].CastDbValue<string>(),
                                 dataRow["Color"].CastDbValue<string>(),
                                 dataRow["Year"].CastDbValue<int>(),
                                 dataRow["DailyPrice"].CastDbValue<decimal>(),
                                 dataRow["RentStatus"].CastDbValue<CarRentStatus>()));
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
