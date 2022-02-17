using Orderly.Core.Domain.Contact;
using Orderly.Models.Comman;
using Orderly.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Contact
{
    public interface IContactService
    {
        Task<List<UserContact>> GetUserContactsAsync(int userId);
        Task<List<UserGroup>> GetUserGroupsAsync(int userId);
        Task<List<UserContact>> GetUserContactByIdsAsync(List<int> ids);
        Task<UserContact> GetUserContactByIdAsync(int id);
        Task<UserGroup> GetUserGroupByIdAsync(int id);
        Task InsertOrUpdateUserContactAsync(ContactModel model);
        Task DeleteUserContactAsync(int id);
        Task InsertOrUpdateUserGroupAsync(UserGroupModel model);
        Task DeleteUserGroupAsync(int id);
        Task<IPagedList<UserContact>> GetPagedListUserContactAsync(int userId, int pageIndex = 0, int pageSize = int.MaxValue);
        Task<IPagedList<UserGroup>> GetPagedListUserGroupAsync(int userId, int pageIndex = 0, int pageSize = int.MaxValue);
        Task<List<UserContact>> GetUserContactsAsync(int userId, int groupId);
        Task<List<int>> GetContactMappingGroupIds(int contactId);
        Task<List<int>> GetContactMappingContactIdsAsync(int groupId);
        Task<UserContact> GetByAddress(string Address);
        Task<List<UserContact>> GetByUserId(int userId);
    }
}
