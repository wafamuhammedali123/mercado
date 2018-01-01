using System.ComponentModel.DataAnnotations;
using System;

namespace mercado.Model
{
    public class InventoryModel
    {
        [Key]
        public int InventoryId { get; set; }
        public string ProductName { get; set; }
        public int ShopId { get; set; }
         public int Price { get; set; }
       
    }
}