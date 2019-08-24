using Perque.Contracts.Dtos;
using System.Collections.Generic;

namespace Perque.Business.Abstractions
{
    public interface ICategoryService
    {
        IEnumerable<BasicDetailedInfoDto> GetCategories();
        BasicDetailedInfoDto GetCategory(int id);
    }
}
