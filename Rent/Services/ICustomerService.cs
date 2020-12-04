using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Creating Customer. Returns Created object with Id from database.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        Customer CreateCustomer(Dictionary<string, string> fields);
        /// <summary>
        /// Deleting Customer. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCustomer(int id);
        /// <summary>
        /// Searching Customer in database. Returns list with all found Customers.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        List<Customer> GetCustomer(Dictionary<string, string> fields);
        /// <summary>
        /// Updating Customer. Returns updated object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        Customer UpdateCustomer(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
