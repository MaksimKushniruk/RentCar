using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal PricePerHour { get; set; }
        public CarStatus Status { get; set; }
        public int BrandId { get; set; }
    }
}
