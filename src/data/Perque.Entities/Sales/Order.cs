using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Sales
{
    [Table("Orders", Schema = "Sales")]
    public class Order : EntityBase
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public double Total { get; set; }
    }
}
