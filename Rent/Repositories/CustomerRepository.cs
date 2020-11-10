using Rent.Models;
using System;
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
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Customers WHERE id = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                Customer customer = null;
                if (reader.HasRows)
                    customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                reader.Close();
                return customer;
            }
        }
        // Перегрузка, ищем всех клиентов, возвращаем в виде объекта DataTable.
        public DataTable GetCustomer()
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
        // Принимаем объект Customer, обновляем его в БД, возвращаем количество измененных записей.
        public int UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Customers SET FirstName = {customer.FirstName}, LastName = {customer.LastName}, PhoneNumber = {customer.PhoneNumber} WHERE Customers.Id = {customer.Id}", connection);                    // добавить
                return command.ExecuteNonQuery();
            }
        }
    }
}
