using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Data.Interfaces
{
    public interface ITemplateRespository
    {
        Task<IEnumerable<Template>> ListTemplateAsync();
        Task<Template> GetTemplateAsync(int? id);
        Task SaveTemplateAsync(Template Template);
        Task DeleteTemplateAsync(DeleteEntityVM deleteTemplateVm);
    }
}
