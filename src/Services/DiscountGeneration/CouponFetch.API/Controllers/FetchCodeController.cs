using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponFetch.API.Entities;
using CouponFetch.API.Repositories;
using System.Net;

namespace CouponFetch.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FetchCodeController:ControllerBase
    {
        private readonly IFetchCode _repository;
        CouponCode coupon = new CouponCode();
        public FetchCodeController(IFetchCode repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        [HttpGet("{brandName}", Name = "Fetchcoupencode")]
        [ProducesResponseType(typeof(IEnumerable<CouponCode>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CouponCode>>> Fetchcoupencode(string brandName)
        {
            var _discountcoupon = await _repository.Fetchcoupencode(brandName);
            return Ok(_discountcoupon);


        }

    }
}
