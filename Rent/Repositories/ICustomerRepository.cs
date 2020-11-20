using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICustomerRepository
    {
        bool AddCustomer(Customer customer, out int id);
        bool DeleteCustomer(int id);
        List<Customer> GetCustomer(CustomerRequest request);
        bool UpdateCustomer(Customer customer);
    }
}
