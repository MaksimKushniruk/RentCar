using System;
using System.Collections.Generic;
using Rent.Models;
using Rent.Services;

namespace ConsoleUI
{
    //public static class Coupon
    //{
    //    public static DiscountCoupon GetDiscountCoupon()
    //    {
    //        IDiscountCouponService discountCouponService = new DiscountCouponService();
    //        while (true)
    //        {
    //            Console.Clear();
    //            ConsoleMenu.Header("Введите данные");
    //            List<string> keys = new List<string> { "Купон" };
    //            Dictionary<string, string> fields = ConsoleMenu.InputData(keys);
    //            DiscountCouponRequest request = new DiscountCouponRequest { Coupon = fields["Купон"] };
    //            List<DiscountCoupon> discountCoupons = discountCouponService.GetDiscountCoupon(request);
    //            Dictionary<string, string> discountCoupon = new Dictionary<string, string>();
    //            ConsoleMenu.MainMenu(new List<string> { "Найти", "Отменить" });
    //            switch (Console.ReadKey().KeyChar)
    //            {
    //                case '1':
    //                    Console.SetCursorPosition(0, Console.CursorTop);
    //                    Console.Clear();
    //                    discountCoupons = discountCouponService.GetDiscountCoupon(new DiscountCouponRequest { Id = Int32.Parse(discountCoupon["Id"]) });
    //                    discountCoupon.Add("Id", discountCoupons[0].Id.ToString());
    //                    discountCoupon.Add("Купон", discountCoupons[0].Coupon);
    //                    discountCoupon.Add("Скидка", discountCoupons[0].Discount.ToString());
    //                    Console.Clear();
    //                    ConsoleMenu.Header("Хотите выбрать текущий купон?");
    //                    ConsoleMenu.Menu(discountCoupon);
    //                    ConsoleMenu.MainMenu(new List<string> { "Да", "Нет", "Назад" });
    //                    switch (Console.ReadKey().KeyChar)
    //                    {
    //                        case '1':
    //                            return discountCoupons[0];
    //                        case '2':
    //                            continue;
    //                        case '3':
    //                            return null;
    //                        default:
    //                            continue;
    //                    }
    //                case '2':
    //                    return null;
    //                default:
    //                    continue;
    //            }
    //        }
    //    }
    //}
}
