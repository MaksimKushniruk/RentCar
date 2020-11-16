using System;

namespace Rent.Models
{
    public class Request
    {
        public int? Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string Color { get; set; }
        public int? Year { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public CarRentStatus? Status { get; set; }
    }
}
