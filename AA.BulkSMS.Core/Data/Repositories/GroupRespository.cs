using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.Interfaces;
using AA.BulkSMS.Models.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Data.Repositories
{
    internal class GroupRespository(DapperContext context) : IGroupRespository
    {
        public async Task DeleteGroupAsync(DeleteEntityVM deleteGroupVm)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", deleteGroupVm.Id);
            parameters.Add("@Email", deleteGroupVm.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }

        public async Task DeleteGroupContact(DeleteEntityVM deleteGroupVm)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", deleteGroupVm.Id);
            parameters.Add("@Email", deleteGroupVm.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }

        public async Task<IEnumerable<Group>> GetGroupAsync(int groupId)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Group_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await multi.ReadAsync<Group>();
        }

        public async Task<IEnumerable<Group>> ListGroupAsync()
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[ListContacts_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await multi.ReadAsync<Group>();
        }

        public async Task<IEnumerable<GroupContact>> ListGroupContact(int groupId)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", groupId);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[ListContacts_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await multi.ReadAsync<GroupContact>();
        }

        public async Task SaveGroupAsync(Group Group)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Group.Id);
            parameters.Add("@Descriptions", Group.Description);
            parameters.Add("@Name", Group.Name);
            parameters.Add("@Email", Group.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Update]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }

        public async Task SaveGroupContact(GroupContact Group)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", Group.ContactId);
            parameters.Add("@GroupId", Group.GroupId);
            parameters.Add("@Email", Group.EmailAddress);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[lnk_Group_Contacts_Save]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }
    }
}
