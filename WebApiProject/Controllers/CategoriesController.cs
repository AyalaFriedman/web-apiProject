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
    public class CategoriesController : ControllerBase
    {
        ICategoriesBL ICategoriesBL;
        IMapper IMapper;
        public CategoriesController(ICategoriesBL ICategoriesBL, IMapper IMapper)
        {
            this.IMapper = IMapper;
            this.ICategoriesBL = ICategoriesBL;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoeyDTO>>> Get()
        {
            List<Category> c = await ICategoriesBL.Get();
            List<CategoeyDTO> dtocat = IMapper.Map<List<Category>, List<CategoeyDTO>>(c);
            if (c == null)
                return NoContent();
            return Ok(dtocat);
        }

       
    }
}
