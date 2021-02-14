using RentCar.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation Get(int id);
        IEnumerable<Reservation> Find(Func<Reservation, bool> predicate);
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int id);
    }
}
