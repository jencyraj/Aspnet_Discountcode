using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Repositories;
using Discount.API.Entities;
using System.Net;
using Bond;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController:ControllerBase
    {
        private readonly IDiscountGenerateRepository _repository;
        coupontable coupon = new coupontable();
        public DiscountController(IDiscountGenerateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        [HttpGet("{brandName}", Name = "GetCoupontable")]
        [ProducesResponseType(typeof(IEnumerable<coupontable>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<coupontable>>> GetCoupontable(string brandName)
        {
            var _discountcoupon = await _repository.GetCoupontable(brandName);
            return Ok(_discountcoupon);


        }
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<coupontable>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<coupontable>> GenerateCouponCode(coupontable coupon, int count, string voucherid)
        {

            await _repository.GenerateCouponCode(coupon,count, voucherid);
            return CreatedAtRoute("GetCoupontable", new { BrandName = coupon.BrandName }, coupon);
        }
        //need to write get coupen code from brand table.
        
    }
}
