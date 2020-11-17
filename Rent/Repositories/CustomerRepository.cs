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
        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.FirstName, c.LastName, c.City, c.PhoneNumber FROM Customers c WHERE id = {id}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                customer = new Customer(dataRow["Id"].CastDbValue<int>(),
                                        dataRow["FirstName"].CastDbValue<string>(),
                                        dataRow["LastName"].CastDbValue<string>(),
                                        dataRow["City"].CastDbValue<string>(),
                                        dataRow["PhoneNumber"].CastDbValue<string>());
            }
            return customer;
        }

        public List<Customer> GetCustomer(string city)
        {
            List<Customer> customers = new List<Customer>();
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.FirstName, c.LastName, c.City, c.PhoneNumber FROM Customers c WHERE c.City = {city}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                customers.Add(new Customer(dataRow["Id"].CastDbValue<int>(),
                                           dataRow["FirstName"].CastDbValue<string>(),
                                           dataRow["LastName"].CastDbValue<string>(),
                                           dataRow["City"].CastDbValue<string>(),
                                           dataRow["PhoneNumber"].CastDbValue<string>()));
            }
            return customers;

        }
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.FirstName, c.LastName, c.City, c.PhoneNumber FROM Customers c", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                customers.Add(new Customer(dataRow["Id"].CastDbValue<int>(),
                                           dataRow["FirstName"].CastDbValue<string>(),
                                           dataRow["LastName"].CastDbValue<string>(),
                                           dataRow["City"].CastDbValue<string>(),
                                           dataRow["PhoneNumber"].CastDbValue<string>()));
            }
            return customers;
        }
        public int UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Customers SET FirstName = {customer.FirstName}, LastName = {customer.LastName}, City = {customer.City}, PhoneNumber = {customer.PhoneNumber} WHERE Customers.Id = {customer.Id}", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
