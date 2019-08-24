using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Perque.Business.Abstractions;
using Perque.Contracts.Dtos;

namespace Perque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
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
    }
}