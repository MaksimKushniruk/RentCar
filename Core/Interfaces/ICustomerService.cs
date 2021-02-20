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
        Task CreateAsync(CustomerDto customerDto);
        Task EditAsync(CustomerDto customerDto);
        Task DeleteAsync(int? id);
        void Dispose();
    }
}
