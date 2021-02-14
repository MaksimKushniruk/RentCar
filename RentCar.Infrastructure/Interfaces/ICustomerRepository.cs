using RentCar.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces
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
