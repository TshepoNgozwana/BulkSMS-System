using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.Entities;
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
    public class MessageRepository(DapperContext context) : IMessageRespository
    {
        public async Task DeleteMessageAsync(DeleteEntityVM deleteMessageVm)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", deleteMessageVm.Id);
            parameters.Add("@Email", deleteMessageVm.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Message_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }

        public async Task<MessageVM> GetMessageAsync(int? id)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Message_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<MessageVM>();
            return Template.FirstOrDefault();
        }

        public async Task<IEnumerable<MessageVM>> ListMessageAsync(int? messageTypeId)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Message_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await multi.ReadAsync<MessageVM>();
        }

        public async Task SaveMessageAsync(SaveMessageVM Message)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@MessageypeId", Message.MessageTypeId);
            parameters.Add("@TemplateId", Message.TemplateId);
            parameters.Add("@GroupId", Message.GroupId);
            parameters.Add("@SubscriberId", Message.SubscriberId);
            parameters.Add("@IncludeAlternativeNumber", Message.IncludeAlternativeNumber);
            parameters.Add("@Message", Message.Message);
            parameters.Add("@CurrentStatusId", Message.CurrentStatusId);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Message_Save]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }
    }
}
