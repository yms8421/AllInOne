using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Infra
{
    [Table("Users", Schema = "Infra")]
    public class User : EntityBase
    {
        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(64)]
        public string Password { get; set; }
    }
}
