using System;

namespace Rent.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // город клиента, нужно реализовать выборку всех заказов по городу
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        // Сделать конструктор через this, чтобы избежать повторения кода.
        public Customer()
        {

        }
        public Customer(int id)
        {
            Id = id;
        }
        public Customer(string firstName, string lastName, string city, string phoneNumber)
        {
            Id = Int32.MinValue;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            PhoneNumber = phoneNumber;
        }
        public Customer(int id, string firstName, string lastName, string city, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
