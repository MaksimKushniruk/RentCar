using Infrastructure.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RentCarDbContext db;

        public ReservationRepository(RentCarDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await db.Reservations.AsNoTracking()
                .Include(r => r.Customer).AsNoTracking()
                .Include(r => r.Car)
                    .ThenInclude(c => c.Brand).AsNoTracking()
                .Include(r => r.Coupon).AsNoTracking()
                .ToListAsync();
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await db.Reservations
                .Include(r => r.Customer).AsNoTracking()
                .Include(r => r.Car)
                    .ThenInclude(c => c.Brand).AsNoTracking()
                .Include(r => r.Coupon).AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await db.Reservations.AddAsync(reservation);
        }

        public void Update(Reservation reservation)
        {
            db.Reservations.Update(reservation);
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
