using System;
using System.Collections.Generic;

namespace Rent.Models
{
    public class Customer
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        // Сделать конструктор через this, чтобы избежать повторения кода.
        public Customer(string firstName, string lastName, string city, string phoneNumber)
        {
            Id = null;
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
