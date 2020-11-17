using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public int AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_AddCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
                command.Parameters.Add(new SqlParameter("@City", customer.City));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", customer.PhoneNumber));
                return command.ExecuteNonQuery();
            }
        }
        public int DeleteCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                return command.ExecuteNonQuery();
            }
        }
        public List<Customer> GetCustomer(CustomerRequest request)
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", request.Id));
                command.Parameters.Add(new SqlParameter("@FirstName", request.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", request.LastName));
                command.Parameters.Add(new SqlParameter("@City", request.City));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", request.PhoneNumber));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer(reader["Id"].CastDbValue<int>(),
                                               reader["FirstName"].CastDbValue<string>(),
                                               reader["LastName"].CastDbValue<string>(),
                                               reader["City"].CastDbValue<string>(),
                                               reader["PhoneNumber"].CastDbValue<string>()));
                }
                reader.Close();
            }
            return customers;
        }
        public int UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", customer.Id));
                command.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
                command.Parameters.Add(new SqlParameter("@City", customer.City));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", customer.PhoneNumber));
                return command.ExecuteNonQuery();
            }
        }
    }
}
