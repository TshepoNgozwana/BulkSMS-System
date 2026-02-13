using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AA.BulkSMS.Core.Data.Entities
{
    public class SystemUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? OtherNames { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(150)]
        public string OrganisationId { get; set; } // FK referencing Organisation.Code

        [ForeignKey("OrganisationId")]
        public Organisation Organisation { get; set; } // Navigation property
    }
}

