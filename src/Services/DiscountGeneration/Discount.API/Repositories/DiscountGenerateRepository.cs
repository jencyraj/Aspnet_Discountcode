using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Entities;
using Npgsql;
using Dapper;
using Bond;

namespace Discount.API.Repositories
{
    public class DiscountGenerateRepository:IDiscountGenerateRepository
    {
        private readonly IConfiguration _configuration;
        public DiscountGenerateRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        List<string> add_list = new List<string>();
        public async Task<coupontable> GetCoupontable(string brandName)
        {
            //create a connection Npga
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            // going to create a coupon informtion
            var coupon = await connection.QueryFirstOrDefaultAsync<coupontable>
                ("SELECT TA.id,brandname,couponcode,amount FROM brand_couponcode BC INNER JOIN  admin_table TA ON TA.id = BC.brand_id WHERE TA.BrandName = @BrandName", new { BrandName = brandName });
               
            if (coupon == null)
            {
                return new coupontable { CouponCode = "No codes generated under this brand ", Amount = 0 };

            }
            return coupon;

        }
        public async Task<bool> GenerateCouponCode(coupontable coupon,int count,string voucherid)
        {
            //coupontable coupon = new coupontable();
            //char[] alphaNumSeed = new char[100];
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //coupon.Brand_Id = 1;
            //coupon.Amount = 30;
            //string voucherid = "614-251-e44-194-805-f57-e84915";
            ConvertIdToVoucherCode(count,voucherid);
            for (int i = 0; i <= add_list.Count; i++)
            {
                var dataaffected =
                    await connection.ExecuteAsync("INSERT INTO brand_couponcode (Brand_Id,couponcode,Amount) VALUES(@Brand_Id,@CouponCode,@Amount)",
                    new { Brand_Id = coupon.Brand_Id, CouponCode = add_list[i], Amount = coupon.Amount });
                if (dataaffected == 0)
                {
                    return false;
                }
            }
            return true;

        }
        public void  ConvertIdToVoucherCode(int count,string voucherId)
        {
            
            /* Here I have some  idea , now I used some alphanumarical value as parameter and converting to couponcode. 
             But we can use Guid ID in our database and , each iteration we can use that id for generating couponcode*/
            int length = 6;
            for (int i =0;i <= count; i++)
            {
                var coupon = voucherId.OrderBy(o => Guid.NewGuid()).Take(length);

                string voucherCode=new string(coupon.ToArray());
                add_list.Add(voucherCode);

            }
            return;
            
        }


    }
}
