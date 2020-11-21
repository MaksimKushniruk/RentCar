using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        bool DeleteCustomer(int id);
        List<Customer> GetCustomer(CustomerRequest request);
        bool UpdateCustomer(Customer customer);
    }
}
