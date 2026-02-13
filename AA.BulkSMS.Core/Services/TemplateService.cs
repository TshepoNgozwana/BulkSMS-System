using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.BulkSMS.Core.Data.Interfaces;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Core.Data.Entities;

namespace AA.BulkSMS.Core.Services
{
    public class TemplateService(ITemplateRespository respository): ITemplateService
    {
        public async Task DeleteTemplateAsync(DeleteEntityVM deleteQuestionVm)
        {
            await respository.DeleteTemplateAsync(deleteQuestionVm);
        }

        public async Task<Template> GetTemplateAsync(int TemplateId)
        {
            return await respository.GetTemplateAsync(TemplateId);
        }

        public async Task<IEnumerable<Template>> ListTemplateAsync()
        {
            return await respository.ListTemplateAsync();
        }

        public async Task SaveTemplateAsync(Template saveTemplate)
        {
            await respository.SaveTemplateAsync(saveTemplate);
        }
    }
}
