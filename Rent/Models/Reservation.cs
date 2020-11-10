using System;

namespace Rent.Models
{
    class Reservation
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
        
        public Reservation()
        {

        }
        public Reservation(int id, Car car, Customer customer, DateTime startDate, DateTime finalDate, decimal price)
        {
            Id = id;
            Car = car;
            Customer = customer;
            StartDate = startDate;
            FinalDate = finalDate;
            Price = price;
        }
        public Reservation(Car car, Customer customer, DateTime startDate, DateTime finalDate, decimal price)
        {
            Id = Int32.MinValue;
            Car = car;
            Customer = customer;
            StartDate = startDate;
            FinalDate = finalDate;
            Price = price;
        }
        public Reservation(int id, int carId, int customerId, DateTime startDate, DateTime finalDate, decimal price)
        {
            Id = id;
            Car = new Car(carId);
            Customer = new Customer(customerId);
            StartDate = startDate;
            FinalDate = finalDate;
            Price = price;
        }
    }
}
