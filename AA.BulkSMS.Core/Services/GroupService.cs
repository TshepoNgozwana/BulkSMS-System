using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.Interfaces;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Services
{
    public class GroupService(IGroupRespository repository) : IGroupService
    {
        public async Task DeleteGroupAsync(DeleteEntityVM deleteGroupVm)
        {
            await repository.DeleteGroupAsync(deleteGroupVm);
        }

        public async Task DeleteGroupContact(DeleteEntityVM deleteGroupVm)
        {
            await repository.DeleteGroupContact(deleteGroupVm);
        }

        public async Task<IEnumerable<Group>> GetGroupAsync(int groupId)
        {
           return await repository.GetGroupAsync(groupId);
        }

        public async Task<IEnumerable<Group>> ListGroupAsync()
        {
            return await repository.ListGroupAsync();
        }

        public async Task<IEnumerable<GroupContact>> ListGroupContact(int groupId)
        {
            return await repository.ListGroupContact(groupId);
        }

        public async Task SaveGroupAsync(Group Group)
        {
            await repository.SaveGroupAsync(Group);
        }

        public async Task SaveGroupContact(GroupContact Group)
        {
            await repository.SaveGroupContact(Group);
        }
    }
}
