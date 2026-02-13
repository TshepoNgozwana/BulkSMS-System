using AA.BulkSMS.Models;
using AA.BulkSMS.Models.ViewModels;
using AA.BulkSMS.Core.Data;
using System.Data;
using AA.BulkSMS.Data;
using Dapper;
using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.ViewModels;

namespace AA.BulkSMS.Core.Data.Repositories
{
    public class ContactRepository(DapperContext context) : IContactRespository
    {
        public async Task<IEnumerable<IndividualContact>> ListContactAsync(int organisationId)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", organisationId);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Contacts_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await multi.ReadAsync<IndividualContact>();
        } 
        public async Task DeleteContactAsync(DeleteContactVM deleteContactVm)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", deleteContactVm.Id);
            parameters.Add("@Email", deleteContactVm.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Contacts_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var contact = await multi.ReadAsync<IndividualContact>();
            return;
        }

        public async Task<IndividualContact> GetContactAsync(int? id)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Contacts_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var contact = await multi.ReadAsync<IndividualContact>();
            return contact.FirstOrDefault();
        }

               

        public async Task SaveContactAsync(SaveContactVM Contact)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", Contact.Id);
            parameters.Add("@EmailAddress", Contact.AddedBy);
            parameters.Add("@CellphoneNumber", Contact.CellphoneNumber);
            parameters.Add("@AlternativeCellNumber", Contact.AlternativeCellNumber);
            parameters.Add("@FirstName", Contact.FirstName);
            parameters.Add("@OtherNames", Contact.OtherNames);
            parameters.Add("@LastName", Contact.LastName);
            parameters.Add("@CellphoneConfirmed", Contact.CellphoneConfirmed);
            parameters.Add("@EmailConfirmed", Contact.EmailConfirmed);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Contacts_Update]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var contact = await multi.ReadAsync<IndividualContact>();
            return;
        }
    }    
}
