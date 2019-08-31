using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("Product", Schema = "Productivity")]
    public class Product : EntityBase
    {
        public Product()
        {
            Images = new List<ProductImage>();
        }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        public bool IsFeatured { get; set; }
        public double Point { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
}
