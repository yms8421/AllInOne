using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Infra
{
    [Table("UserRoles", Schema = "Infra")]
    public class UserRole : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
