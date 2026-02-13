using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Data.Entities
{
    public class SaveGroupContact
    {
        public string AddedBy { get; set; }
        public int GroupId { get; set; }
        public int ContactId { get; set; }
    }
}
