using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICustomerService
    {
        bool CreateCustomer(out int customerId, string firstName, string lastName, string city, string phoneNumber);
        bool DeleteCustomer(int id);
        List<Customer> GetCustomer(CustomerRequest request);
        bool UpdateCustomer(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
