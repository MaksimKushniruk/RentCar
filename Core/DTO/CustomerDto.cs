using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class CustomerDto : BaseEntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
