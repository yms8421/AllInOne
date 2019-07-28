using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Productivity
{
    [Table("Suppliers", Schema = "Productivity")]
    public class Supplier : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string ContactName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string EMail { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        //TODO: City ?
    }
}
