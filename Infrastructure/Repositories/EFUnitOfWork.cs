using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly RentCarDbContext db;
        private CarRepository carRepository;
        private CustomerRepository customerRepository;
        private CouponRepository couponRepository;
        private ReservationRepository reservationRepository;
        private BrandRepository brandRepository;
        private CartRepository cartRepository;

        public EFUnitOfWork(RentCarDbContext context)
        {
            db = context;
        }

        public ICarRepository Cars
        {
            get
            {
                if (carRepository == null)
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
                if (customerRepository == null)
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
                if (couponRepository == null)
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
                if (reservationRepository == null)
                {
                    reservationRepository = new ReservationRepository(db);
                }
                return reservationRepository;
            }
        }

        public IBrandRepository Brands
        {
            get
            {
                if (brandRepository == null)
                {
                    brandRepository = new BrandRepository(db);
                }
                return brandRepository;
            }
        }

        public ICartRepository Carts
        {
            get
            {
                if(cartRepository == null)
                {
                    cartRepository = new CartRepository(db);
                }
                return cartRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
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
