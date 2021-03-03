using Core.DTO;
using Core.Interfaces;
using Core.Validation;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _database;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(await _database.Customers.GetAllAsync());
        }

        public async Task<CustomerDto> GetAsync(int? id)
        {
            if (id == null)
            {
                throw new RentCarValidationException(String.Empty, "Id is not set");
            }
            Customer customer = await _database.Customers.GetAsync(id.Value);
            if (customer == null)
            {
                throw new RentCarValidationException(String.Empty, "Customer is not found");
            }
            var mapper = new MapperConfiguration(cfg => 
                cfg.CreateMap<Customer, CustomerDto>())
                    .CreateMapper();
            return mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task CreateAsync(CustomerDto customerDto)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            await _database.Customers.CreateAsync(mapper.Map<CustomerDto, Customer>(customerDto));
            await _database.SaveAsync();
        }

        public async Task EditAsync(CustomerDto customerDto)
        {
            Customer customer = await _database.Customers.GetAsync(customerDto.Id);
            if (customer == null)
            {
                throw new RentCarValidationException(String.Empty, "Customer is not found");
            }
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(dst => dst.Reservations, opt => opt.Ignore());
            }).CreateMapper();
            _database.Customers.Update(mapper.Map<CustomerDto, Customer>(customerDto));
            await _database.SaveAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id != null)
            {
                _database.Customers.Delete(id.Value);
                await _database.SaveAsync();
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
