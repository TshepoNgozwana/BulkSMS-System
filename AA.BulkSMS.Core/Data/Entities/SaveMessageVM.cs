using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Data.Entities
{
    public class SaveMessageVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MessageTypeId { get; set; }
        public int TemplateId { get; set; }
        public int GroupId { get; set; }
        public int SubscriberId { get; set; }
        public bool IncludeAlternativeNumber { get; set; }
        public string Message { get; set; }
        public int CurrentStatusId { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
