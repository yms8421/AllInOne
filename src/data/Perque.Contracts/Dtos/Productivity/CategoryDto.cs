using System.Collections.Generic;

namespace Perque.Contracts.Dtos.Productivity
{
    public class CategoryDto : DtoBase
    {
        public string Name { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}
