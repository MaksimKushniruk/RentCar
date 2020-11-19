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
        public List<Customer> GetCustomer(CustomerRequest request)
        {
            return CustomerRepository.GetCustomer(request);
        }
        public int UpdateCustomer(int id, Dictionary<string, string> fieldsForUpdate)           
        {
            List<Customer> customers = CustomerRepository.GetCustomer(new CustomerRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("FirstName"))
            {
                customers[0].FirstName = fieldsForUpdate["FirstName"];
            }
            if (fieldsForUpdate.ContainsKey("LastName"))
            {
                customers[0].LastName = fieldsForUpdate["LastName"];
            }
            if (fieldsForUpdate.ContainsKey("City"))
            {
                customers[0].City = fieldsForUpdate["City"];
            }
            if (fieldsForUpdate.ContainsKey("PhoneNumber"))
            {
                customers[0].PhoneNumber = fieldsForUpdate["PhoneNumber"];
            }
            return CustomerRepository.UpdateCustomer(customers[0]);
        }
    }
}
