using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rent.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository CustomerRepository { get; }
        public CustomerService()
        {
            CustomerRepository = new CustomerRepository();
        }
        /// <summary>
        /// Creating Customer. Returns Created object with Id from database.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Customer CreateCustomer(Dictionary<string, string> fields)
        {
            int id = CustomerRepository.AddCustomer(new Customer(fields["First name"], 
                                                                 fields["Last name"], 
                                                                 fields["City"], 
                                                                 fields["Phone number"]));
            return new Customer(id, 
                                fields["First name"], 
                                fields["Last name"], 
                                fields["City"], 
                                fields["Phone number"]);
        }
        /// <summary>
        /// Deleting Customer. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        {
            return CustomerRepository.DeleteCustomer(id);
        }
        /// <summary>
        /// Searching Customer in database. Returns list with all found Customers.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<Customer> GetCustomer(Dictionary<string, string> fields)
        {
            return CustomerRepository.GetCustomer(new CustomerRequest(fields["Id"].ToNullableInt(), 
                                                                      fields["First name"], 
                                                                      fields["Last name"], 
                                                                      fields["City"], 
                                                                      fields["Phone number"]));
        }
        /// <summary>
        /// Updating Customer. Returns updated object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        public Customer UpdateCustomer(int id, Dictionary<string, string> fieldsForUpdate)           
        {
            List<Customer> customers = CustomerRepository.GetCustomer(new CustomerRequest { Id = id });
            customers.FirstOrDefault().FirstName = fieldsForUpdate["First name"];
            customers.FirstOrDefault().LastName = fieldsForUpdate["Last name"];
            customers.FirstOrDefault().City = fieldsForUpdate["City"];
            customers.FirstOrDefault().PhoneNumber = fieldsForUpdate["Phone number"];
            CustomerRepository.UpdateCustomer(customers.FirstOrDefault());
            return customers.FirstOrDefault();
        }
    }
}