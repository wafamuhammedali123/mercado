using System.ComponentModel.DataAnnotations;
using System;

namespace mercado.Model
{
    public class ShopModel
    {
        [Key]
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Rating  { get; set; }
    }
}