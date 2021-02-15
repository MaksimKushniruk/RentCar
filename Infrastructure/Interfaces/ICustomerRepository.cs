using Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        IEnumerable<Customer> Find(Func<Customer, bool> predicate);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
