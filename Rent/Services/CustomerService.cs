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
        public int CreateCustomer(string firstName, string lastName, string city, string phoneNumber)
        {
            return CustomerRepository.AddCustomer(new Customer(firstName, lastName, city, phoneNumber));
        }
        public int DeleteCustomer(int id)
        {
            return CustomerRepository.DeleteCustomer(id);
        }
        public List<Customer> GetCustomer(int? id, string firstName, string lastName, string city, string phoneNumber)
        {
            return CustomerRepository.GetCustomer(new CustomerRequest(id, firstName, lastName, city, phoneNumber));
        }
        // Принимать дикшинари параметров которые надо изменить и менять даже если будет налл.
        public int UpdateCustomer(Dictionary<string, string> fields)           
        {
            return CustomerRepository.UpdateCustomer(customer);
        }
    }
}
