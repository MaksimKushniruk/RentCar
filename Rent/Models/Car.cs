using System;

namespace Rent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
        public CarRentStatus Status { get; set; }
        // Сделать конструктор через this, чтобы избежать повторения кода.
        public Car()
        {

        }
        public Car(string registrationNumber, string modelName, string brandName, string color, int year, decimal dailyPrice)
        {
            Id = Int32.MinValue;
            RegistrationNumber = registrationNumber;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            DailyPrice = dailyPrice;
            Status = CarRentStatus.Free;
        }
        public Car(int id, string registrationNumber, string modelName, string brandName, string color, int year, decimal dailyPrice, CarRentStatus carRentStatus)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            DailyPrice = dailyPrice;
            Status = carRentStatus;
        }
    }
}
