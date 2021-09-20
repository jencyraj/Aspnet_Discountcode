using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponFetch.API.Entities;
using CouponFetch.API.Repositories;
using Dapper;

using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CouponFetch.API.Repositories
{
    public class FetchCode:IFetchCode
    {
        private readonly IConfiguration _configuration;
        public FetchCode(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<CouponCode> Fetchcoupencode(string brandName)
        {
            CouponCode coupon = new CouponCode();
            NpgsqlConnection conn = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from  public.brand_couponcode BC inner join public.admin_table TA on TA.id=BC.brand_id where TA.brandname = '" + brandName + "' ", conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                coupon.CId = (int)dr[0];
                coupon.Brand_Id = (int)dr[1];
                coupon.couponcode = (string)dr[2];
                coupon.Amount = (int)dr[3];
                coupon.BrandName = (string)dr[5];



            }


                ////create a connection Npga
                //using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                ////connection.Open();
                ////NpgsqlCommand command = new NpgsqlCommand("select * from  public.brand_couponcode BC inner join public.admin_table TA on TA.id=BC.brand_id where TA.brandname = '" + brandName + "' ", connection);
                ////List<List<string>> pipes = new List<List<string>>();
                ////NpgsqlDataReader dr = command.ExecuteReader();

                //// going to create a coupon informtion
                //var affected = await connection.QueryFirstOrDefaultAsync<CouponCode>
                //    ("select * from  public.brand_couponcode BC inner join public.admin_table TA on TA.id=BC.brand_id where TA.brandname = @brandName",
                //     new { BrandName = brandName });



                if (coupon == null)
            {
                return new CouponCode { couponcode = "No codes generated under this brand ", Amount = 0 };

            }
            return coupon;

        }
    }
}
