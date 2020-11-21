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
                command.Parameters.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@RegistrationNumber", car.RegistrationNumber));
                command.Parameters.Add(new SqlParameter("@ModelName", car.ModelName));
                command.Parameters.Add(new SqlParameter("@BrandName", car.BrandName));
                command.Parameters.Add(new SqlParameter("@Color", car.Color));
                command.Parameters.Add(new SqlParameter("@Year", car.Year));
                command.Parameters.Add(new SqlParameter("@DailyPrice", car.DailyPrice));
                command.Parameters.Add(new SqlParameter("@RentStatus", (int)car.Status));
                command.ExecuteNonQuery();
                // Возвращаем Id созданного объекта
                return command.Parameters["@Id"].Value.CastDbValue<int>();
            }
        }
        public bool DeleteCar(int id)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteCar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                int result =  command.ExecuteNonQuery();
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

        public List<Car> GetCar(CarRequest request)
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetCar", connection);            
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", request.Id));
                command.Parameters.Add(new SqlParameter("@RegistrationNumber", request.RegistrationNumber));
                command.Parameters.Add(new SqlParameter("@ModelName", request.ModelName));
                command.Parameters.Add(new SqlParameter("@BrandName", request.BrandName));
                command.Parameters.Add(new SqlParameter("@Color", request.Color));
                command.Parameters.Add(new SqlParameter("@Year", request.Year));
                command.Parameters.Add(new SqlParameter("@MinPrice", request.MinPrice));
                command.Parameters.Add(new SqlParameter("@MaxPrice", request.MaxPrice));
                command.Parameters.Add(new SqlParameter("@RentStatus", request.Status));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cars.Add(new Car(reader["Id"].CastDbValue<int>(), 
                                     reader["RegistrationNumber"].CastDbValue<string>(), 
                                     reader["ModelName"].CastDbValue<string>(), 
                                     reader["BrandName"].CastDbValue<string>(), 
                                     reader["Color"].CastDbValue<string>(), 
                                     reader["Year"].CastDbValue<int>(), 
                                     reader["DailyPrice"].CastDbValue<decimal>(), 
                                     reader["RentStatus"].CastDbValue<CarRentStatus>()));
                }
                reader.Close();
            }
            return cars;
        }
        public bool UpdateCar(Car car)
        {
            using(SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateCar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", car.Id));
                command.Parameters.Add(new SqlParameter("@RegistrationNumber", car.RegistrationNumber));
                command.Parameters.Add(new SqlParameter("@ModelName", car.ModelName));
                command.Parameters.Add(new SqlParameter("@BrandName", car.BrandName));
                command.Parameters.Add(new SqlParameter("@Color", car.Color));
                command.Parameters.Add(new SqlParameter("@Year", car.Year));
                command.Parameters.Add(new SqlParameter("@DailyPrice", car.DailyPrice));
                command.Parameters.Add(new SqlParameter("@RentStatus", (int)car.Status));
                int result =  command.ExecuteNonQuery();
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
