using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        // GET: api/<FirstController>
        [HttpGet]
        public string Get()
        {
      
            return HttpContext.User.Identity.Name == null ? "anonymous Authentication": HttpContext.User.Identity.Name;
        }

        // GET api/<FirstController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FirstController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FirstController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FirstController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
