
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Customer()
        {
            Reservations = new List<Reservation>();
        }
    }
}
