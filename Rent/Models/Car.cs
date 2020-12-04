using System;

namespace Rent.Models
{
    /// <summary>
    /// The base object Car. 
    /// </summary>
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
        public Car()
        {
            // empty
        }
        public Car(string licensePlate, string modelName, string brandName, string color, int year, decimal pricePerHour)
        {
            Id = Int32.MinValue;
            LicensePlate = licensePlate;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            PricePerHour = pricePerHour;
            Status = CarRentStatus.Free;
        }
        public Car(int id, string licensePlate, string modelName, string brandName, string color, int year, decimal pricePerHour)
        {
            Id = id;
            LicensePlate = licensePlate;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            PricePerHour = pricePerHour;
            Status = CarRentStatus.Free;
        }
        public Car(int id, string licensePlate, string modelName, string brandName, string color, int year, decimal pricePerHour, CarRentStatus carRentStatus)
        {
            Id = id;
            LicensePlate = licensePlate;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            PricePerHour = pricePerHour;
            Status = carRentStatus;
        }
    }
}
