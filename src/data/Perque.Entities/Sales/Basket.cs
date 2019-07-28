using Perque.Entities.Productivity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Sales
{
    [Table("Baskets", Schema = "Sales")]
    public class Basket : EntityBase
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int CustomerId { get; set; } //TODO: entity?
        [Required]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
