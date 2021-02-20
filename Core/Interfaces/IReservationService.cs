using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllAsync();
        Task<ReservationDto> GetAsync(int? id);
        Task CreateAsync(ReservationDto reservationDto);
        Task EditAsync(ReservationDto reservationDto);
        Task DeleteAsync(int? id);
        void Dispose();
    }
}