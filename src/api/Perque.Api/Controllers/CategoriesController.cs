using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perque.Business.Abstractions;
using Perque.Contracts;
using Perque.Contracts.Dtos;
using Perque.Contracts.Dtos.Productivity;

namespace Perque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public List<BasicDetailedInfoDto> Get()
        {
            return service.GetCategories().ToList();
        }

        [HttpGet("{id}")]
        public BasicDetailedInfoDto Get(int id)
        {
            return service.GetCategory(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoryDto data)
        {
            var result =  service.NewCategory(data);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}