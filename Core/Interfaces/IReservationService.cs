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
        void Edit(ReservationDto reservationDto);
        void Delete(int? id);
        void Dispose();
    }
}