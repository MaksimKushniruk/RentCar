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
            CustomerRepository.AddCustomer(new Customer(firstName, lastName, phoneNumber));
            return "Успешно добавлено";
        }
        // Принимаем Id удаляемого клиента, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public string DeleteCustomer(int id)
        {
            CustomerRepository.DeleteCustomer(id);
            return "Успешно удалено";
        }
        // Принимаем Id искомого автомобиля, передаем в репозиторий для поиска, проверяем успешность через возвращаемый результат.
        public Customer GetCustomer(int id)
        {
            Customer customer = CustomerRepository.GetCustomer(id);
            return customer;
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = CustomerRepository.GetCustomer();
            return customers;
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public string UpdateCustomer(Customer customer)
        {
            CustomerRepository.UpdateCustomer(customer);
            return "Успешно изменено";
        }
    }
}
