using System;

namespace Rent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal PricePerHour { get; set; }
        public CarRentStatus Status { get; set; }
        // Сделать конструктор через this, чтобы избежать повторения кода.
        public Car()
        {

        }
        public Car(string registrationNumber, string modelName, string brandName, string color, int year, decimal pricePerHour)
        {
            Id = Int32.MinValue;
            LicensePlate = registrationNumber;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            PricePerHour = pricePerHour;
            Status = CarRentStatus.Free;
        }
        public Car(int id, string registrationNumber, string modelName, string brandName, string color, int year, decimal pricePerHour, CarRentStatus carRentStatus)
        {
            Id = id;
            LicensePlate = registrationNumber;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            PricePerHour = pricePerHour;
            Status = carRentStatus;
        }
    }
}
