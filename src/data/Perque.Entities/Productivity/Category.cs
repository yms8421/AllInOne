using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("Categories", Schema = "Productivity")]
    public class Category : EntityBase
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
