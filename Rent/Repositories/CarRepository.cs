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
                SqlCommand command = new SqlCommand("sp_AddCar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RegistrationNumber", car.RegistrationNumber));
                command.Parameters.Add(new SqlParameter("@ModelName", car.ModelName));
                command.Parameters.Add(new SqlParameter("@BrandName", car.BrandName));
                command.Parameters.Add(new SqlParameter("@Color", car.Color));
                command.Parameters.Add(new SqlParameter("@Year", car.Year));
                command.Parameters.Add(new SqlParameter("@DailyPrice", car.DailyPrice));
                command.Parameters.Add(new SqlParameter("@RentStatus", (int)car.Status));
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
                SqlCommand command = new SqlCommand("sp_GetCar", connection);            
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", (object)request.Id ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@RegistrationNumber", (object)request.RegistrationNumber ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@ModelName", (object)request.ModelName ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@BrandName", (object)request.BrandName ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Color", (object)request.Color ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Year", (object)request.Year ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@MinPrice", (object)request.MinPrice ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@MaxPrice", (object)request.MaxPrice ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("@RentStatus", (object)request.Status ?? DBNull.Value));

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
