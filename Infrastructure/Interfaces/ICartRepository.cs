using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetAsync(string username);
        Task CreateAsync(Cart cart);
        void Update(Cart cart);
        void Delete(int id);
    }
}
