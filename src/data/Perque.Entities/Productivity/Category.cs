using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("Categories", Schema = "Productivity")]
    public class Category : EntityBase
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
