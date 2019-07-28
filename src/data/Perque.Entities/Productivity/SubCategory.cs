using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("SubCategories", Schema = "Productivity")]
    public class SubCategory : EntityBase
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
