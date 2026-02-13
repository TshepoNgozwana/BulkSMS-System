using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Data.Entities
{
    public class GroupContact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Groups { get; set; }
        public string EmailAddress { get; set; }
        public string CellphoneNumber { get; set; }
        public string AlternativeCellNumber { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string LastName { get; set; }
        public bool CellphoneConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int GroupId { get; set; }
        public int ContactId { get; set; }
    }
}
