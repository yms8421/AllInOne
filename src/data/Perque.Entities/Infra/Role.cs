using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Infra
{
    [Table("Roles", Schema = "Infra")]
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
