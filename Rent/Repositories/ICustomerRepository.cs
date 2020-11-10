using System;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        int DeleteCustomer(int id);
        Customer GetCustomer(int id);
        DataTable GetCustomer();
        int UpdateCustomer(Customer customer);
    }
}
