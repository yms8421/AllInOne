using Perque.Business.Abstractions;
using Perque.Contracts.Dtos.Productivity;
using Perque.Data;
using Perque.Entities.Productivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Perque.Business
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Product> repo;
        Expression<Func<Product, ProductListDto>> map = i => new ProductListDto
        {
            Id = i.Id,
            Name = i.Name,
            ImagePath = "/Images/photo.png",
            Price = i.Price,
            Rating = 4.5
        };

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = unitOfWork.GetRepository<Product>();
        }
        public IEnumerable<ProductListDto> GetAll()
        {
            return repo.Select(map).ToList();
        }

        public IEnumerable<ProductListDto> GetBestRated()
        {
            return repo.OrderByDescending(i => i.Point).Take(3).Select(map).ToList();
        }

        public IEnumerable<ProductListDto> GetFeatured()
        {
            return repo.Where(i => i.IsFeatured).Select(map).ToList();
        }

        public IEnumerable<ProductListDto> GetNewProducts()
        {
            return repo.OrderByDescending(i => i.CreatedDate).Take(3).Select(map).ToList();
        }

        public IEnumerable<ProductListDto> GetTopSellers()
        {
            return repo.Take(3).Select(map).ToList();
        }
    }
}
