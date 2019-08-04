using System.Collections.Generic;

namespace Perque.Contracts.Dtos
{
    public class BasicDetailedInfoDto : DtoBase
    {
        public BasicDetailedInfoDto()
        {
            Children = new List<BasicDetailedInfoDto>();
        }
        public string Name { get; set; }
        public List<BasicDetailedInfoDto> Children { get; set; }
    }
}
