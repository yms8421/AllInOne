using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("Stocks", Schema = "Productivity")]
    public class Stock : EntityBase
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public int Amount { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }
    }
}
