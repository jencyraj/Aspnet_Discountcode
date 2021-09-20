using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponFetch.API.Entities;

namespace CouponFetch.API.Repositories
{
    public interface IFetchCode
    {
        Task<CouponCode> Fetchcoupencode(string brandName);
    }
}
