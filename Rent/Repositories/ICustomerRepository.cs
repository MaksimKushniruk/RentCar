using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        int DeleteCustomer(int id);
        List<Customer> GetCustomer(CustomerRequest request);
        int UpdateCustomer(Customer customer);
    }
}
