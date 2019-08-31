using Perque.Contracts.Dtos.Productivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perque.Business.Abstractions
{
    public interface IProductService
    {
        IEnumerable<ProductListDto> GetAll();
        IEnumerable<ProductListDto> GetTopSellers();
        IEnumerable<ProductListDto> GetNewProducts();
        IEnumerable<ProductListDto> GetBestRated();
        IEnumerable<ProductListDto> GetFeatured();
    }
}
