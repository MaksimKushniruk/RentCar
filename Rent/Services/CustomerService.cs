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
        public Customer CreateCustomer(Dictionary<string, string> fields)
        {
            int id = CustomerRepository.AddCustomer(new Customer(fields["Имя"], 
                                                                 fields["Фамилия"], 
                                                                 fields["Город"], 
                                                                 fields["Телефон"]));
            return new Customer(id, 
                                fields["Имя"], 
                                fields["Фамилия"], 
                                fields["Город"], 
                                fields["Телефон"]);
        }
        public bool DeleteCustomer(int id)
        {
            return CustomerRepository.DeleteCustomer(id);
        }
        public List<Customer> GetCustomer(Dictionary<string, string> fields)
        {
            return CustomerRepository.GetCustomer(new CustomerRequest(Int32.Parse(fields["Id"]), 
                                                                                  fields["First name"], 
                                                                                  fields["Last name"], 
                                                                                  fields["City"], 
                                                                                  fields["Phone number"]));
        }
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