using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Models.ViewModels;

namespace AA.BulkSMS.Core.Services.ServiceInterfaces
{
    public interface IContactService
    {
        Task<IEnumerable<IndividualContact>> ListContactAsync(int organisationId);
        Task<IndividualContact> GetContactAsync(int contactId);
        Task SaveContactAsync(SaveContactVM questionBankDetail);
        Task DeleteContactAsync(DeleteContactVM deleteQuestionVm);
    }
}
