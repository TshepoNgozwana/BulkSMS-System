using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Data.ViewModels
{
    public class SaveTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TemplateBody { get; set; }
        public string AddedBy { get; set; }
    }
}
