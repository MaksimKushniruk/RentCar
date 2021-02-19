using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RentCarDbContext db;

        public CustomerRepository(RentCarDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Customer customer)
        {
            await db.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            db.Customers.Update(customer);
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
