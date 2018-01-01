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
    public class ShopController : Controller
    {
        private readonly ShopRepository shopRepository;
        public ShopController()
        {
            shopRepository = new ShopRepository();
        }
        

        // POST api/shop
        //Insert
        [HttpPost]
        public void Post([FromBody]ShopModel shop)
        {
            if (ModelState.IsValid)
                shopRepository.Add(shop);
        }

        // PUT api/todo/5
        //Update 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ShopModel shop)
        {
            shop.ShopId = id;
            if (ModelState.IsValid)
                shopRepository.Update(shop);
        }

       
    }
}
