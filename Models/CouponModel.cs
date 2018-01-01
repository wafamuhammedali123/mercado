using System.ComponentModel.DataAnnotations;
using System;

namespace mercado.Model
{
    public class CouponModel
    {
        [Key]
        public int CouponId { get; set; }
        public string InventoryId { get; set; }
        public int UserId { get; set; }
         public bool Validity { get; set; }
       
    }
}