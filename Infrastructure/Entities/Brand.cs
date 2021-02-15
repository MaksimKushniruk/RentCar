using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Brand : BaseEntity
    {
        public string Title { get; set; }
        public List<Car> Cars { get; set; }
    }
}
