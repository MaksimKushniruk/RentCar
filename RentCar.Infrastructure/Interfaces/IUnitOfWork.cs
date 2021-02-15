using RentCar.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        ICustomerRepository Customers { get; }
        ICouponRepository Coupons { get; }
        IReservationRepository Reservations { get; }
        IBrandRepository Brands { get; }
        void Save();
    }
}
