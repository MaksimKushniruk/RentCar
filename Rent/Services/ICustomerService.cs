using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Dictionary<string, string> fields);
        bool DeleteCustomer(int id);
        List<Customer> GetCustomer(Dictionary<string, string> fields);
        bool UpdateCustomer(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
