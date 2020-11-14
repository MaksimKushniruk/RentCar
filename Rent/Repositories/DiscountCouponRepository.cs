using Rent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rent.Repositories
{
    public class DiscountCouponRepository : IDiscountCouponRepository
    {
        public int AddDiscountCoupon(DiscountCoupon discountCoupon)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO DiscountCoupons (Coupon, Discount) VALUES ('{discountCoupon.Coupon}', {discountCoupon.Discount})", connection);
                return command.ExecuteNonQuery();
            }
        }

        public int DeleteDiscountCoupon(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM DiscountCoupons WHERE id = {id}", connection);
                return command.ExecuteNonQuery();
            }
        }

        public DiscountCoupon GetDiscountCoupon(int id)
        {
            DiscountCoupon discountCoupon = null;
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT dc.Id, dc.Coupon, dc.Discount FROM DiscountCoupons dc WHERE dc.Id = {id}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                discountCoupon = new DiscountCoupon(dataRow["Id"].CastDbValue<int>(),
                                                    dataRow["Coupon"].CastDbValue<string>(),
                                                    dataRow["Discount"].CastDbValue<int>());
            }
            return discountCoupon;
        }

        public List<DiscountCoupon> GetDiscountCoupon()
        {
            List<DiscountCoupon> discountCoupons = new List<DiscountCoupon>();
            DataTable dataTable;
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT dc.Id, dc.Coupon, dc.Discount FROM DiscountCoupons dc", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                discountCoupons.Add(new DiscountCoupon(dataRow["Id"].CastDbValue<int>(),
                                                       dataRow["Coupon"].CastDbValue<string>(),
                                                       dataRow["Discount"].CastDbValue<int>()));
            }
            return discountCoupons;
        }

        public int UpdateDiscountCoupon(DiscountCoupon discountCoupon)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE DiscountCoupons SET Coupon = {discountCoupon.Coupon}, Discount = {discountCoupon.Discount} WHERE Cars.Id = {discountCoupon.Id}", connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
