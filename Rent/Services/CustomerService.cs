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
        public int CreateCustomer(string firstName, string lastName, string city, string phoneNumber)
        {
            return CustomerRepository.AddCustomer(new Customer(firstName, lastName, city, phoneNumber));
        }
        // Принимаем Id удаляемого клиента, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public int DeleteCustomer(int id)
        {
            return CustomerRepository.DeleteCustomer(id);
        }
        // Принимаем Id искомого автомобиля, передаем в репозиторий для поиска, проверяем успешность через возвращаемый результат.
        public Customer GetCustomer(int id)
        {
            return CustomerRepository.GetCustomer(id);
        }

        public List<Customer> GetCustomer(string city)
        {
            return CustomerRepository.GetCustomer(city);
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Customer> GetCustomer()
        {
            return CustomerRepository.GetCustomer();
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public int UpdateCustomer(Customer customer)
        {
            return CustomerRepository.UpdateCustomer(customer);
        }
    }
}
