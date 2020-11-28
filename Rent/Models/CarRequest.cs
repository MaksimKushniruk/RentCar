using System;

namespace Rent.Models
{
    public class CarRequest
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
        public CarRequest()
        {

        }
        public CarRequest(int? id, string registrationNumber, string modelName, string brandName, string color, int? year, decimal? minPrice, decimal? maxPrice)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            ModelName = modelName;
            BrandName = brandName;
            Color = color;
            Year = year;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            Status = CarRentStatus.Free;
        }
    }
}
