using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetAllAsync();
        Task<CartDto> GetAsync(string username);
        Task CreateAsync(CartDto cartDto);
        Task EditAsync(CartDto cartDto);
        Task DeleteAsync(string username);
        void Dispose();
    }
}
