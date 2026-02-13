using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AA.BulkSMS.Core.Data.Entities
{
    [Table("Organisation")]
    public class Organisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key (Auto-increment)

        [Required]
        [MaxLength(150)]
        public string Code { get; set; } // This will be used as the FK in SystemUser

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string AddedBy { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        // Navigation property
        public ICollection<SystemUser> Users { get; set; }
    }
}
