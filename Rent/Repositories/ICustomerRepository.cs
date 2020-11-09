using System;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        void UpdateCustomer(int id, string firstName, string lastName, string phoneNumber);
        void DeleteCustomer(Customer customer);
        void ReadCustomer(int id);
    }
}
