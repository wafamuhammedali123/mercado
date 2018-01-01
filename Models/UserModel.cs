using System.ComponentModel.DataAnnotations;
using System;

namespace mercado.Model
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
      
    }
}