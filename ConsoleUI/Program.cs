using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            IReservationService reservationService = new ReservationService();
            Reservation reservation = reservationService.GetReservation(1);
            if(reservation == null)
            {
                Console.WriteLine("Объект не найден");
            }
            else
            {
                Console.WriteLine($"{reservation.Id} {reservation.Customer.FirstName} {reservation.Car.ModelName}");
            }
            Console.ReadKey();
        }
    }
}
