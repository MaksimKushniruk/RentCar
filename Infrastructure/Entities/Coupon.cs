
namespace Infrastructure.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; }
        public int Discount { get; set; }
    }
}
