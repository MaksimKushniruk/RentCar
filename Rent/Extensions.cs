using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent
{
    public static class Extensions
    {
        /// <summary>
        /// Trying parse string to CarRentStatus. Returns "Free" if can't parse.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Trying parse string to nullable int. Returns null if can't parse.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToNullableInt(this string s)
        {
            if (int.TryParse(s, out int i)) return i;
            return null;
        }
        /// <summary>
        /// Trying parse string to nullable decimal. Returns null if can't parse.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(this string s)
        {
            if (decimal.TryParse(s, out decimal i)) return i;
            return null;
        }
        /// <summary>
        /// Converting Reservation to Dictionary<string, string>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Converting Customer to Dictionary<string, string>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Converting Car to Dictionary<string, string>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Converting DiscountCoupon to Dictionary<string, string>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this DiscountCoupon value)
        {
            Dictionary<string, string> discountCouponDictionary = new Dictionary<string, string>();
            discountCouponDictionary["Id"] = value.Id.ToString();
            discountCouponDictionary["Coupon"] = value.Coupon;
            discountCouponDictionary["Discount"] = value.Discount.ToString();
            return discountCouponDictionary;
        }
        /// <summary>
        /// Check for DBNull and return default value or object value if object is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T CastDbValue<T>(this object value)
        {
            try
            {
                return value == DBNull.Value ? default(T) : (T)value;
            }
            catch
            {
                // ignore
            }

            return default(T);
        }
    }
}
