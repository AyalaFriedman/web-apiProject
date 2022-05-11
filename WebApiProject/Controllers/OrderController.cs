using AutoMapper;
using BL;
using DTO;
using Entities;
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
    public class OrderController : ControllerBase
    {
        IOrederBL IOrederBL;
        IMapper mapper;
        public OrderController(IOrederBL IOrederBL, IMapper mapper)
        {
            this.IOrederBL = IOrederBL;
            this.mapper = mapper;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody]OrderDTO order)
        {
            
            Order orderPost = await IOrederBL.Post(mapper.Map<Order>(order));  
            if (order != null)
                return mapper.Map<OrderDTO>(orderPost);
            return NoContent();
        }

    }
}
