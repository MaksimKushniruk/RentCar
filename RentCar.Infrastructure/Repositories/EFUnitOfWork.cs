﻿using RentCar.DataAccess.EF;
using RentCar.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly RentCarDbContext db;
        private CarRepository carRepository;
        private CustomerRepository customerRepository;
        private CouponRepository couponRepository;
        private ReservationRepository reservationRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new RentCarDbContext(connectionString);
        }

        public ICarRepository Cars
        {
            get
            {
                if(carRepository == null)
                {
                    carRepository = new CarRepository(db);
                }
                return carRepository;
            }
        }

        public ICustomerRepository Customers
        {
            get
            {
                if(customerRepository == null)
                {
                    customerRepository = new CustomerRepository(db);
                }
                return customerRepository;
            }
        }

        public ICouponRepository Coupons
        {
            get
            {
                if(couponRepository == null)
                {
                    couponRepository = new CouponRepository(db);
                }
                return couponRepository;
            }
        }

        public IReservationRepository Reservations
        {
            get
            {
                if(reservationRepository == null)
                {
                    reservationRepository = new ReservationRepository(db);
                }
                return reservationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}