using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BulkSMS.Core.Services.ServiceInterfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroupAsync(int groupId);
        Task<IEnumerable<Group>> ListGroupAsync();
        Task<IEnumerable<GroupContact>> ListGroupContact(int groupId);
        Task SaveGroupAsync(Group Group);
        Task SaveGroupContact(GroupContact Group);
        Task DeleteGroupAsync(DeleteEntityVM deleteGroupVm);
        Task DeleteGroupContact(DeleteEntityVM deleteGroupVm);
    }
}
