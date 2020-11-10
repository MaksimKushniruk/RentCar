using System;

namespace Rent.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        // Сделать конструктор через this, чтобы избежать повторения кода.
        public Customer()
        {

        }
        public Customer(string firstName, string lastName, string phoneNumber)
        {
            Id = Int32.MinValue;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public Customer(int id, string firstName, string lastName, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
