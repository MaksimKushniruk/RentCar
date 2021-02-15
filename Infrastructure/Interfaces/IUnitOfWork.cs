using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
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
