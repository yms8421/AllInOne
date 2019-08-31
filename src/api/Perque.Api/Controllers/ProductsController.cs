using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Perque.Business.Abstractions;
using Perque.Contracts.Dtos.Productivity;

namespace Perque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IEnumerable<ProductListDto> Get()
        {
            return service.GetAll();
        }

        [HttpGet("top")]
        public IEnumerable<ProductListDto> TopSellers()
        {
            return service.GetTopSellers();
        }

        [HttpGet("new")]
        public IEnumerable<ProductListDto> NewProducts()
        {
            return service.GetNewProducts();
        }

        [HttpGet("best")]
        public IEnumerable<ProductListDto> BestRated()
        {
            return service.GetBestRated();
        }

        [HttpGet("featured")]
        public IEnumerable<ProductListDto> Featured()
        {
            return service.GetFeatured();
        }
    }
}