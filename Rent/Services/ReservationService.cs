using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rent.Services
{
    class ReservationService : IReservationService
    {
        private IReservationRepository ReservationRepository { get; }
        public ReservationService()
        {
            ReservationRepository = new ReservationRepository();
        }
        // Принимаем информацию-поля резервирования, создаем новый объект, передаем в репозиторий для записи, проверяем успешность через возвращаемый результат.
        public string CreateReservation(Car car, Customer customer, DateTime startDate, DateTime finalDate, decimal price)
        {
            ReservationRepository.AddReservation(new Reservation(car, customer, startDate, finalDate, price));
            return "Успешно добавлено";
        }
        // Принимаем Id удаляемого резервирования, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public string DeleteReservation(int id)
        {
            ReservationRepository.DeleteReservation(id);
            return "Успешно удалено";
        }
        // Принимаем Id искомого резервирования, передаем в репозиторий для поиска, получаем Reservation, проверяем успешность через возвращаемый результат.
        public Reservation GetReservation(int id)
        {
            Reservation reservation = ReservationRepository.GetReservation(id);
            return reservation;
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Reservation> GetReservation()
        {
            // Проверить на null
            List<Reservation> reservations = ReservationRepository.GetReservation();
            return reservations;
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public string UpdateReservation(Reservation reservation)
        {
            ReservationRepository.UpdateReservation(reservation);
            return "Успешно изменено";
        }
    }
}
