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
                SqlCommand command = new SqlCommand("sp_AddDiscountCoupon", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                command.Parameters.Add(new SqlParameter("@Coupon", discountCoupon.Coupon));
                command.Parameters.Add(new SqlParameter("@Discount", discountCoupon.Discount));
                command.ExecuteNonQuery();
                // Возвращаем Id созданного объекта
                return command.Parameters["@Id"].Value.CastDbValue<int>();
            }
        }

        public bool DeleteDiscountCoupon(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteDiscountCoupon", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request)
        {
            List<DiscountCoupon> discountCoupons = new List<DiscountCoupon>();
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetDiscountCoupon", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", request.Id));
                command.Parameters.Add(new SqlParameter("@Coupon", request.Coupon));
                command.Parameters.Add(new SqlParameter("@MinDiscount", request.MinDiscount));
                command.Parameters.Add(new SqlParameter("@MaxDiscount", request.MaxDiscount));

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    discountCoupons.Add(new DiscountCoupon(reader["Id"].CastDbValue<int>(),
                                                           reader["Coupon"].CastDbValue<string>(),
                                                           reader["Discount"].CastDbValue<int>()));
                }
                reader.Close();
            }
                
            return discountCoupons;
        }

        public bool UpdateDiscountCoupon(DiscountCoupon discountCoupon)
        {
            using (SqlConnection connection = new SqlConnection(Constantes.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateDiscountCoupon", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", discountCoupon.Id));
                command.Parameters.Add(new SqlParameter("@Coupon", discountCoupon.Coupon));
                command.Parameters.Add(new SqlParameter("@Discount", discountCoupon.Discount));
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
