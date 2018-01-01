using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mercado.Repository;
using Microsoft.AspNetCore.Mvc;
using mercado.Model;

namespace mercado.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly InventoryRepository inventoryRepository;
        public InventoryController()
        {
            inventoryRepository = new InventoryRepository();
        }
        
        //Display all
        [HttpGet]
        public IEnumerable<InventoryModel> Get() => inventoryRepository.GetAll();



        // POST api/inventory
        //Insert
        [HttpPost]
        public void Post([FromBody]InventoryModel inventory)
        {
            if (ModelState.IsValid)
                inventoryRepository.AddInventory(inventory);
        }

        // PUT api/inventory/5
        //Update 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]InventoryModel inventory)
        {
            inventory.InventoryId = id;
            if (ModelState.IsValid)
                inventoryRepository.UpdateInventory(inventory);
        }

        [HttpGet("search/{search}")]
        public IEnumerable<Product> Search(string search)
        {
            return inventoryRepository.SearchInventory(search);
        }

       
    }
}
