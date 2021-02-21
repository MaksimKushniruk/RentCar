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
        public CarStatusViewModel Status { get; set; }
        public BrandViewModel Brand { get; set; }
        public List<ReservationViewModel> Reservations { get; set; }
        public CarViewModel()
        {
            Reservations = new List<ReservationViewModel>();
        }
    }
}
