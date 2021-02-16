using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IReservationService
    {
        IEnumerable<CarDto> GetAllCars();
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCutomer(int? id);
        CarDto GetCar(int? id);
        CouponDto GetCoupon(string couponCode);
        void MakeReservation(ReservationDto reservationDto);
        void Dispose();
    }
}