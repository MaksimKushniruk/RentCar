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
        // Сделать конструктор через this, чтобы избежать повторения кода.
        public Car()
        {
            
        }
        public Car(int id)
        {
            Id = id;
        }
        public Car(string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            Id = Int32.MinValue;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            DailyPrice = dailyPrice;
        }
        public Car(int id, string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            Id = id;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            DailyPrice = dailyPrice;
        }
    }
}
