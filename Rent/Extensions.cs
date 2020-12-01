using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent
{
    public static class Extensions
    {
        public static CarRentStatus ToCarRentStatus(this string value)
        {
            if (value != null)
            {
                return (CarRentStatus)Enum.Parse(typeof(CarRentStatus), value);
            }
            else
            {
                return CarRentStatus.Free;
            }
        }
        public static int? ToNullableInt(this string s)
        {
            if (int.TryParse(s, out int i)) return i;
            return null;
        }
        public static decimal? ToNullableDecimal(this string s)
        {
            if (decimal.TryParse(s, out decimal i)) return i;
            return null;
        }
        public static Dictionary<string, string> ToDictionary(this Reservation value)
        {
            Dictionary<string, string> reservationDictionary = new Dictionary<string, string>();
            reservationDictionary["Id"] = value.Id.ToString();
            reservationDictionary["Car Id"] = value.Car.Id.ToString();
            reservationDictionary["Customer Id"] = value.Customer.Id.ToString();
            reservationDictionary["Discount Coupon Id"] = value.DiscountCoupon.Id.ToString();
            reservationDictionary["Start Date"] = value.StartDate.ToString();
            reservationDictionary["Final Date"] = value.FinalDate.ToString();
            reservationDictionary["Price"] = value.Price.ToString();
            return reservationDictionary;
        }
        public static Dictionary<string, string> ToDictionary(this Customer value)
        {
            Dictionary<string, string> customerDictionary = new Dictionary<string, string>();
            customerDictionary["Id"] = value.Id.ToString();
            customerDictionary["First name"] = value.FirstName;
            customerDictionary["Last name"] = value.LastName;
            customerDictionary["City"] = value.City;
            customerDictionary["Phone number"] = value.PhoneNumber;
            return customerDictionary;
        }
        public static Dictionary<string, string> ToDictionary(this Car value)
        {
            Dictionary<string, string> carDictionary = new Dictionary<string, string>();
            carDictionary["Id"] = value.Id.ToString();
            carDictionary["License plate"] = value.LicensePlate;
            carDictionary["Model"] = value.ModelName;
            carDictionary["Brand"] = value.BrandName;
            carDictionary["Color"] = value.Color;
            carDictionary["Year"] = value.Year.ToString();
            carDictionary["Price per hour"] = value.PricePerHour.ToString();
            carDictionary["Status"] = value.Status.ToString();
            return carDictionary;
        }
        public static Dictionary<string, string> ToDictionary(this DiscountCoupon value)
        {
            Dictionary<string, string> discountCouponDictionary = new Dictionary<string, string>();
            discountCouponDictionary["Id"] = value.Id.ToString();
            discountCouponDictionary["Coupon"] = value.Coupon;
            discountCouponDictionary["Discount"] = value.Discount.ToString();
            return discountCouponDictionary;
        }
        // Приводит к нужному типу объект, возвращаемый из БД, если объект null, возвращает значение по умолчанию
        public static T CastDbValue<T>(this object value)
        {
            try
            {
                return value == DBNull.Value ? default(T) : (T)value;
            }
            catch
            {
                // игнорируем
            }

            return default(T);
        }
        // Проверка на равенство строк, с удаление пробелов, учетом языка, региональных параметров и без учета регистра
        public static bool IsEquals(this string strA, string strB)
        {
            // если А null, то возвращаем true, если В null, и false если B не null
            if (string.IsNullOrEmpty(strA))
            {
                return string.IsNullOrEmpty(strB);
            }
            // если А ну null, а В null, то возвращаем false
            if (string.IsNullOrEmpty(strB))
            {
                return false;
            }
            // сравниваем строки с обрезанием пробелов, учетом языка, без учета регистра
            return strA.Trim().Equals(strB.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        // Формат обратного преобразования даты и времени. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz"
        public static string FormatDateTime(this DateTime datetime)
        {
            return datetime.ToString("o");
        }
        // Возвращает строку, где число представлено в виде формата N(2 цифры после запятой)  -12,445.68
        public static string FormatDecimal(this decimal value)
        {
            return value.ToString("N2");
        }
        // Возвращает строку с разницой во времени 
        public static string GetTimeDifference(DateTime start, DateTime end)
        {
            var diff = end.Subtract(start);
            return $"{diff.Hours} hrs {diff.Minutes} mins {diff.Seconds} secs";
        }
    }
}
