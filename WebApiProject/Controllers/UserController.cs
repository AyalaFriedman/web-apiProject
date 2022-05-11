using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Entities;
using BL;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IuserBL iuserBL;
        public UserController(IuserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> Get(string email, int password)
        {
            User user = await iuserBL.Get(email, password);
            if(user == null)
                return NoContent();
            return Ok(user);

        }
        [HttpPut("{id}")]
        public async Task<User> Put([FromBody] User user, int id)
        {
            await iuserBL.Put(user, id);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User user1 = await iuserBL.Post(user);
            if (user1 != null)
            return Ok(user1);
         return NoContent();
        }
    }
}



