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
        Customer GetCustomer(int id);
        List<Customer> GetCustomer(string city);
        List<Customer> GetCustomer();
        int UpdateCustomer(Customer customer);
    }
}
