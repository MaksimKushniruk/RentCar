using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        CustomerDto Get(int? id);
        void Create(CustomerDto customerDto);
        void Edit(CustomerDto customerDto);
        void Delete(int? id);
        void Dispose();
    }
}
