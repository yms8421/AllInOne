using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("ProductImages", Schema = "Productivity")]
    public class ProductImage : EntityBase
    {
        [Required]
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string Label { get; set; }
        [MaxLength(256)]
        public string Path { get; set; }
        public bool IsMainImage { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
