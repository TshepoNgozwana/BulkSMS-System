using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AA.BulkSMS.Core.Data
{
    public class IndividualContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EmailAddress { get; set; }
        public string CellphoneNumber { get; set; }
        public string AlternativeCellNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string LastName { get; set; }
        public bool? CellphoneConfirmed { get; set; }
        public bool? EmailConfirmed { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }

}
