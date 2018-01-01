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
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }



        // POST api/user
        //Insert
        [HttpPost]
        public void Post([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
                userRepository.Add(user);
        }

        // PUT api/user/5
        //Update 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UserModel user)
        {
            user.UserId = id;
            if (ModelState.IsValid)
                userRepository.Update(user);
        }

        //POST api/user/login
        [HttpPost("login")]
        public UserModel Login([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
                return userRepository.Login(user);
            else return null;
        }


    }
}
