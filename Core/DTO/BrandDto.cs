using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class BrandDto : BaseEntityDto
    {
        public string Title { get; set; }
        public List<CarDto> Cars { get; set; }
        public BrandDto()
        {
            Cars = new List<CarDto>();
        }
    }
}
