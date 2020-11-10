using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rent.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository CustomerRepository { get; }
        public CustomerService()
        {
            CustomerRepository = new CustomerRepository();
        }
        // Принимаем информацию-поля клиента, создаем новый объект, передаем в репозиторий для записи, проверяем успешность через возвращаемый результат.
        public string CreateCustomer(string firstName, string lastName, string phoneNumber)
        {
            int success = CustomerRepository.AddCustomer(new Customer(firstName, lastName, phoneNumber));
            if (success > 0)
                return "Успешно добавлено";
            else
                throw new Exception("Ошибка добавления данных.");
        }
        // Принимаем Id удаляемого клиента, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public string DeleteCustomer(int id)
        {
            int success = CustomerRepository.DeleteCustomer(id);
            if (success > 0)
                return "Успешно удалено";
            else
                throw new Exception("Ошибка удаления данных.");
        }
        // Принимаем Id искомого автомобиля, передаем в репозиторий для поиска, проверяем успешность через возвращаемый результат.
        public Customer GetCustomer(int id)
        {
            Customer customer = CustomerRepository.GetCustomer(id);
            if (customer != null)
                return customer;
            else
                throw new Exception("Не удалось найти объект.");
        }
        // Перегрузка методы, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            DataTable dataTable = CustomerRepository.GetCustomer();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                customers.Add(new Customer((int)dataRow.ItemArray[0], (string)dataRow.ItemArray[1], (string)dataRow.ItemArray[2], (string)dataRow.ItemArray[3]));
            }
            if (customers.Count > 0)
                return customers;
            else
                throw new Exception("Не удалось получить данные.");
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public string UpdateCustomer(Customer customer)
        {
            int success = CustomerRepository.UpdateCustomer(customer);
            if (success > 0)
                return "Успешно изменено";
            else
                throw new Exception("Изменение не удалось");
        }
    }
}
