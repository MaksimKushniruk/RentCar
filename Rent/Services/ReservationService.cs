using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rent.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository ReservationRepository { get; }
        public ReservationService()
        {
            ReservationRepository = new ReservationRepository();
        }
        // Принимаем информацию-поля резервирования, создаем новый объект, передаем в репозиторий для записи, проверяем успешность через возвращаемый результат.
        public int CreateReservation(Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal price)
        {
            return ReservationRepository.AddReservation(new Reservation(car, customer, discountCoupon, startDate, finalDate, price));
        }
        // Принимаем Id удаляемого резервирования, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public int DeleteReservation(int id)
        {
            return ReservationRepository.DeleteReservation(id);
        }
        // Принимаем Id искомого резервирования, передаем в репозиторий для поиска, получаем Reservation, проверяем успешность через возвращаемый результат.
        public Reservation GetReservation(int id)
        {
            return ReservationRepository.GetReservation(id);
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Reservation> GetReservation()
        {
            // Проверить на null
            return ReservationRepository.GetReservation();
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public int UpdateReservation(Reservation reservation)
        {
            return ReservationRepository.UpdateReservation(reservation);
        }
    }
}
