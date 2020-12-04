using System;
using System.Collections.Generic;
using System.Data;
using Rent.Models;

namespace Rent.Repositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Adding object to database. Returns id of added Customer.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int AddCustomer(Customer customer);
        /// <summary>
        /// Deleting Customer from database. Returns bool result of Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCustomer(int id);
        /// <summary>
        /// Searching Customer or Customers in database. Returns all found Customers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<Customer> GetCustomer(CustomerRequest request);
        /// <summary>
        /// Updating Customer in database. Returns bool result of operation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        bool UpdateCustomer(Customer customer);
    }
}
