using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Infra
{
    [Table("LookUpTypes", Schema = "Infra")]
    public class LookUpType : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(40)]
        [Required]
        public string Code { get; set; }
    }
}
