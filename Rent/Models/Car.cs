using System;

namespace Rent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
