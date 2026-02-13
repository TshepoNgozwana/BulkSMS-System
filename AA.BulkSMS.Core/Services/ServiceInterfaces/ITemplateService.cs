using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.BulkSMS.Core.Data.Entities;

namespace AA.BulkSMS.Core.Services.ServiceInterfaces
{
    public interface ITemplateService
    {
        Task<IEnumerable<Template>> ListTemplateAsync();
        Task<Template> GetTemplateAsync(int TemplateId);
        Task SaveTemplateAsync(Template template);
        Task DeleteTemplateAsync(DeleteEntityVM deleteQuestionVm);
    }
}
