using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetAsync(int id);
        Task CreateAsync(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int id);
    }
}
