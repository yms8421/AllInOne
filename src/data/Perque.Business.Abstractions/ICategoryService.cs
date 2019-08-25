using Perque.Contracts.Dtos;
using Perque.Contracts.Dtos.Productivity;
using System.Collections.Generic;

namespace Perque.Business.Abstractions
{
    public interface ICategoryService
    {
        IEnumerable<BasicDetailedInfoDto> GetCategories();
        BasicDetailedInfoDto GetCategory(int id);
        bool NewCategory(CategoryDto data);
    }
}
