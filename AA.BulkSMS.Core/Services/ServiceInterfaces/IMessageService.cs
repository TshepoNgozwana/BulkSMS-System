using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Services.ServiceInterfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageVM>> ListMessageAsync(int? messageTypeId);
        Task<MessageVM> GetMessageAsync(int MessageId);
        Task SaveMessageAsync(SaveMessageVM Message);
        Task DeleteMessageAsync(DeleteEntityVM deleteQuestionVm);
    }
}
