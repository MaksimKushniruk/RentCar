using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICustomerService
    {
        int CreateCustomer(string firstName, string lastName, string city, string phoneNumber);
        int DeleteCustomer(int id);
        Customer GetCustomer(int id);
        List<Customer> GetCustomer(string city);
        List<Customer> GetCustomer();
        int UpdateCustomer(Customer customer);
    }
}
