using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // Добавляем клиента и возвращаем количество изммененных записей.
        public int AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Customers (FirstName, LastName, PhoneNumber) VALUES ('{customer.FirstName}', '{customer.LastName}', '{customer.PhoneNumber}')", connection);
                return command.ExecuteNonQuery();
            }
        }
        // Удаляем клиента и возвращаем количество измененных записей.
        public int DeleteCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Customers WHERE id = {id}", connection);
                return command.ExecuteNonQuery();
            }
        }
        // Ищем клиента по Id, возвращаем объект Customer.
        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.FirstName, c.LastName, c.PhoneNumber FROM Customers c WHERE id = {id}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                customer = new Customer(dataRow["Id"].CastDbValue<int>(),
                                        dataRow["FirstName"].CastDbValue<string>(),
                                        dataRow["LastName"].CastDbValue<string>(),
                                        dataRow["PhoneNumber"].CastDbValue<string>());
            }
            return customer;
        }
        // Перегрузка, ищем всех клиентов, возвращаем в виде объекта List<Customer>.
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT c.Id, c.FirstName, c.LastName, c.PhoneNumber FROM Customers c", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                customers.Add(new Customer(dataRow["Id"].CastDbValue<int>(),
                                           dataRow["FirstName"].CastDbValue<string>(),
                                           dataRow["LastName"].CastDbValue<string>(),
                                           dataRow["PhoneNumber"].CastDbValue<string>()));
            }
            return customers;
        }
        // Принимаем объект Customer, обновляем его в БД, возвращаем количество измененных записей.
        public int UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Customers SET FirstName = {customer.FirstName}, LastName = {customer.LastName}, PhoneNumber = {customer.PhoneNumber} WHERE Customers.Id = {customer.Id}", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
