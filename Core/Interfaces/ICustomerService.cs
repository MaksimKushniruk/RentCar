using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetAsync(int? id);
        Task CreateASync(CustomerDto customerDto);
        void Edit(CustomerDto customerDto);
        void Delete(int? id);
        void Dispose();
    }
}
