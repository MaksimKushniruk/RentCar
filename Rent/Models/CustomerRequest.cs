﻿using System;

namespace Rent.Models
{
    public class CustomerRequest
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerRequest(int? id, string firstName, string lastName, string city, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
