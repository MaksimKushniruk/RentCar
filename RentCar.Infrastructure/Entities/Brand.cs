using RentCar.DataAccess.Entities;
using System.Collections.Generic;

namespace RentCar.Infrastructure.Entities
{
    public class Brand : BaseEntity
    {
        public string Title { get; set; }
        public List<Car> Cars { get; set; }
    }
}
