using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class CouponDto : BaseEntityDto
    {
        public string CouponCode { get; set; }
        public int Discount { get; set; }
    }
}
