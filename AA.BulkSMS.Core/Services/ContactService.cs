using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.ViewModels;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Models.ViewModels;
using Azure.Core;

namespace AA.BulkSMS.Core.Services
{
    public class ContactService(IContactRespository repository) : IContactService
    {
        public async Task DeleteContactAsync(DeleteContactVM deleteQuestionVm)
        {
            await repository.DeleteContactAsync(deleteQuestionVm);
        }

        public async Task<IndividualContact> GetContactAsync(int contactId)
        {
            return await repository.GetContactAsync(contactId);
        }

        public async Task<IEnumerable<IndividualContact>> ListContactAsync(int organisationId)
        {
            return await repository.ListContactAsync(organisationId);
        }

        public async Task SaveContactAsync(SaveContactVM saveContact)
        {
            await repository.SaveContactAsync(saveContact);
        }
    }
}
