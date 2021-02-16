using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RentCarDbContext db;

        public ReservationRepository(RentCarDbContext context)
        {
            db = context;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return db.Reservations.ToList();
        }

        public Reservation Get(int id)
        {
            return db.Reservations.Find(id);
        }

        public void Create(Reservation reservation)
        {
            db.Reservations.Add(reservation);
        }

        public void Update(Reservation reservation)
        {
            db.Reservations.Update(reservation);
        }

        public IEnumerable<Reservation> Find(Func<Reservation, bool> predicate)
        {
            return db.Reservations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation != null)
            {
                db.Reservations.Remove(reservation);
            }
        }
    }
}
