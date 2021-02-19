using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _database;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        // TOTO: Use Automapper
        public IEnumerable<CustomerDto> GetAll()
        {
            IEnumerable<Customer> customers = _database.Customers.GetAll();
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach(Customer customer in customers)
            {
                customerDtos.Add(new CustomerDto
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    City = customer.City,
                    PhoneNumber = customer.PhoneNumber
                });
            }
            return customerDtos;
        }

        public CustomerDto Get(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Customer customer = _database.Customers.Get(id.Value);
            if (customer == null)
            {
                throw new RentCarValidationException(String.Empty, "Customer is not found");
            }
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                City = customer.City,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public void Create(CustomerDto customerDto)
        {
            Customer customer = new Customer
            {
                Id = customerDto.Id,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                City = customerDto.City,
                PhoneNumber = customerDto.PhoneNumber
            };
            _database.Customers.Create(customer);
            _database.Save();
        }

        public void Edit(CustomerDto customerDto)
        {
            Customer customer = _database.Customers.Get(customerDto.Id);
            if (customer == null)
            {
                throw new RentCarValidationException(String.Empty, "Customer is not found");
            }
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.City = customerDto.City;
            customer.PhoneNumber = customerDto.PhoneNumber;
            _database.Customers.Update(customer);
            _database.Save();
        }

        public void Delete(int? id)
        {
            if (id != null)
            {
                _database.Customers.Delete(id.Value);
                _database.Save();
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
