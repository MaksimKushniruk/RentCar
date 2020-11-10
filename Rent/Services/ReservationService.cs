using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

// Приведение значений из DataTable для добавления в List, как обойтись без приведения?

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
            int success = ReservationRepository.AddReservation(new Reservation(car, customer, startDate, finalDate, price));
            if (success > 0)
                return "Успешно добавлено";
            else
                throw new Exception("Ошибка добавления данных.");
        }
        // Принимаем Id удаляемого резервирования, передаем в репозиторий, проверяем успешность через возвращаемый результат.
        public string DeleteReservation(int id)
        {
            int success = ReservationRepository.DeleteReservation(id);
            if (success > 0)
                return "Успешно удалено";
            else
                throw new Exception("Ошибка удаления данных.");
        }
        // Принимаем Id искомого резервирования, передаем в репозиторий для поиска, получаем Reservation, проверяем успешность через возвращаемый результат.
        public Reservation GetReservation(int id)
        {
            Reservation reservation = ReservationRepository.GetReservation(id);
            if (reservation != null)
                return reservation;
            else
                throw new Exception("Не удалось найти объект.");
        }
        // Перегрузка метода, не принимаем параметры, получаем из репозитория объект DataTable, конвертируем его в List и возвращаем его.
        public List<Reservation> GetReservation()
        {
            List<Reservation> reservations = new List<Reservation>();
            DataTable dataTable = ReservationRepository.GetReservation();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                reservations.Add(new Reservation((int)dataRow.ItemArray[0], new Car((int)dataRow.ItemArray[6], (string)dataRow.ItemArray[7], (string)dataRow.ItemArray[8], (string)dataRow.ItemArray[9], (int)dataRow.ItemArray[10], (decimal)dataRow.ItemArray[11]), new Customer((int)dataRow.ItemArray[12], (string)dataRow.ItemArray[13], (string)dataRow.ItemArray[14], (string)dataRow.ItemArray[15]), (DateTime)dataRow.ItemArray[3], (DateTime)dataRow.ItemArray[4], (decimal)dataRow.ItemArray[5]));
            }
            if (reservations.Count > 0)
                return reservations;
            else
                throw new Exception("Не удалось получить данные.");
        }
        // Получаем из UI уже измененный объект и передаем его в репозиторий.
        public string UpdateReservation(Reservation reservation)
        {
            int success = ReservationRepository.UpdateReservation(reservation);
            if (success > 0)
                return "Успешно изменено";
            else
                throw new Exception("Изменение не удалось");
        }
    }
}
