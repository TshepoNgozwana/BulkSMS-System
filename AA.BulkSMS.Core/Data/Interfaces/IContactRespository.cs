using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Models.ViewModels;

namespace AA.BulkSMS.Core.Data
{
    public interface IContactRespository
    {
        Task<IEnumerable<IndividualContact>> ListContactAsync(int organisationId);
        Task<IndividualContact> GetContactAsync(int? id);
        Task SaveContactAsync(SaveContactVM Contact);
        Task DeleteContactAsync(DeleteContactVM deleteContactVm);
    }
}
