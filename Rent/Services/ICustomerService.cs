using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICustomerService
    {
        string CreateCustomer(string firstName, string lastName, string phoneNumber);
        string DeleteCustomer(int id);
        Customer GetCustomer(int id);
        List<Customer> GetCustomer();
        string UpdateCustomer(Customer customer);
    }
}
