using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RentCarDbContext db;

        public CustomerRepository(RentCarDbContext context)
        {
            db = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            db.Customers.Update(customer);
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return db.Customers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
            }
        }
    }
}
