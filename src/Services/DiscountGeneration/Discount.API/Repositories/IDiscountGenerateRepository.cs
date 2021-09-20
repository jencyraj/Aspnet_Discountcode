using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bond;
using Discount.API.Entities;
namespace Discount.API.Repositories
{
    public interface IDiscountGenerateRepository
    {
        Task<coupontable> GetCoupontable(string brandname);
        Task<bool> GenerateCouponCode(coupontable coupon,int count, string voucherid);// like update



    }
}
