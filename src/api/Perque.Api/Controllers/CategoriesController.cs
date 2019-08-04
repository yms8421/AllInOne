using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Perque.Business.Abstractions;
using Perque.Contracts.Dtos;
using Perque.Data;
using Perque.Entities.Productivity;

namespace Perque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public List<BasicInfoDto> Get()
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