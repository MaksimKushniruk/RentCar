
namespace Infrastructure.Entities
{
    public class Car : BaseEntity
    {
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal PricePerHour { get; set; }
        public CarRentStatus Status { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
