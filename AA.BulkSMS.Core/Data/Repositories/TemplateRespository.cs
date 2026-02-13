using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.Interfaces;
using AA.BulkSMS.Core.Data.ViewModels;
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
    public class TemplateRespository(DapperContext context) : ITemplateRespository
    {
        public async Task<IEnumerable<Template>> ListTemplateAsync()
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await multi.ReadAsync<Template>();
        }
        public async Task DeleteTemplateAsync(DeleteEntityVM deleteTemplateVm)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", deleteTemplateVm.Id);
            parameters.Add("@Email", deleteTemplateVm.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Delete]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }

        public async Task<Template> GetTemplateAsync(int? id)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Get]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return Template.FirstOrDefault();
        }



        public async Task SaveTemplateAsync(Template template)
        {
            using IDbConnection db = context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", template.Id);
            parameters.Add("@EmailAddress", template.AddedBy);
            parameters.Add("@Name", template.AddedBy);
            parameters.Add("@TemplateBody", template.AddedBy);
            await using var multi = await db.QueryMultipleAsync(
                "[dbo].[Templates_Update]",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            var Template = await multi.ReadAsync<Template>();
            return;
        }
    }
}
