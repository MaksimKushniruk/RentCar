using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class CarDto : BaseEntityDto
    {
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal PricePerHour { get; set; }
        public bool IsFree { get; set; }

        public int BrandId { get; set; }
        public BrandDto Brand { get; set; }
    }
}
