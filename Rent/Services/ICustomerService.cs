using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICustomerService
    {
        int CreateCustomer(string firstName, string lastName, string phoneNumber);
        void UpdateCustomer(int id);
        void DeleteCustomer(int id);
        Customer GetCustomer(int id);
        List<Customer> GetCustomer();
    }
}
