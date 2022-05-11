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
    public class ProductController : ControllerBase
    {
        IProductBL IProductBL;
        IMapper IMapper;
        public ProductController(IProductBL IProductBL, IMapper IMapper)
        {
            this.IProductBL = IProductBL;
            this.IMapper = IMapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> l = await IProductBL.Get();
           
            if (l == null)
                return NoContent();
            return Ok(l);
        }

        // GET api/<ProductController>/5
        [HttpGet("{category}")]
        public async Task<ActionResult<List<Product>>> Get(int category)
        {
            List<Product> l = await IProductBL.Get(category);
            if (l == null)
                return NoContent();
            return Ok(l);
        }
    }
}
