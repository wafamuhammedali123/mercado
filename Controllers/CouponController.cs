using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mercado.Model;
using mercado.Repository;
using Microsoft.AspNetCore.Mvc;


namespace mercado.Controllers
{
    [Route("api/[controller]")]
    public class CouponController : Controller
    {
        private readonly CouponRepository couponRepository;
        public CouponController()
        {
            couponRepository = new CouponRepository();
        }
        

        // POST api/coupon
        //Insert
        [HttpPost]
        public void Post([FromBody]CouponModel coupon)
        {
            if (ModelState.IsValid)
                couponRepository.Add(coupon);
        }

       
       
    }
}
