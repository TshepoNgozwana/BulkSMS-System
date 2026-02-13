using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Models.ViewModels;

namespace AA.BulkSMS.Core.Data
{
    public interface IMessageRespository
    {
        Task<IEnumerable<MessageVM>> ListMessageAsync(int? organisationId);
        Task<MessageVM> GetMessageAsync(int? id);
        Task SaveMessageAsync(SaveMessageVM Message);
        Task DeleteMessageAsync(DeleteEntityVM deleteContactVm);
    }
}
