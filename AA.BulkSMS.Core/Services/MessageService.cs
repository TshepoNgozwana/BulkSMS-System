using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Services
{
    public class MessageService(IMessageRespository repository) : IMessageService
    {
        public async Task DeleteMessageAsync(DeleteEntityVM deleteVm)
        {
            await repository.DeleteMessageAsync(deleteVm);
        }

        public async Task<MessageVM> GetMessageAsync(int MessageId)
        {
            return await repository.GetMessageAsync(MessageId);
        }

        public async Task<IEnumerable<MessageVM>> ListMessageAsync(int? messageTypeId)
        {
            return await repository.ListMessageAsync(messageTypeId);
        }

        public async Task SaveMessageAsync(SaveMessageVM Message)
        {
            await repository.SaveMessageAsync(Message);
        }
    }
}
