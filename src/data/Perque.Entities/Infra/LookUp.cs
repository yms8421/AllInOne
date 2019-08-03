using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Infra
{
    [Table("LookUps", Schema = "Infra")]
    public class LookUp : EntityBase
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int LookUpTypeId { get; set; }
        public int? UpLookUpId { get; set; }

        [ForeignKey(nameof(LookUpTypeId))]
        public virtual LookUpType Type { get; set; }
        [ForeignKey(nameof(UpLookUpId))]
        public virtual LookUp Parent { get; set; }
    }
}
