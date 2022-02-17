using Microsoft.EntityFrameworkCore;
using Orderly.Core.Domain.Contact;
using Orderly.Helpers;
using Orderly.Models.Comman;
using Orderly.Models.Contact;
using Orderly.Repositories;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Contact
{
    public class ContactService : IContactService
    {
        #region Properties
        private readonly IRepository<UserContact> _userContactRepository;
        private readonly IRepository<UserGroup> _userGroupRepository;
        private readonly IRepository<UserContactGroupMapping> _userContactGroupMappingRepository;
        private readonly IApplicationUser _applicationUser;
        #endregion

        #region Constructor
        public ContactService(IRepository<UserContact> userContactRepository,
            IRepository<UserGroup> userGroupRepository,
            IApplicationUser applicationUser,
            IRepository<UserContactGroupMapping> userContactGroupMappingRepository)
        {
            _userContactRepository = userContactRepository;
            _userGroupRepository = userGroupRepository;
            _applicationUser = applicationUser;
            _userContactGroupMappingRepository = userContactGroupMappingRepository;
        }
        #endregion
        public async Task DeleteUserContactAsync(int id)
        {
            var contact = await GetUserContactByIdAsync(id);
            if (contact != null)
            {
                var mappings = await (await _userContactGroupMappingRepository.GetAllAsync(x => x.Contact.Id == id))
                    //.Include(x => x.Contact)
                    //.Include(x => x.Group)
                    .ToListAsync();

                await _userContactGroupMappingRepository.DeleteAllAsync(mappings);

                await _userContactRepository.DeleteAsync(await GetUserContactByIdAsync(id));
            }
        }

        public async Task DeleteUserGroupAsync(int id)
        {
            var contact = await GetUserGroupByIdAsync(id);
            if (contact != null)
            {
                var mappings = await (await _userContactGroupMappingRepository.GetAllAsync(x => x.Group.Id == id))
                    //.Include(x => x.Contact)
                    //.Include(x => x.Group)
                    .ToListAsync();

                await _userContactGroupMappingRepository.DeleteAllAsync(mappings);

                await _userGroupRepository.DeleteAsync(await GetUserGroupByIdAsync(id));
            }

        }

        public async Task<UserContact> GetUserContactByIdAsync(int id)
        {
            return (await _userContactRepository.GetAllAsync(x => x.Id == id))
                .Include(x => x.GroupMapping)
                .FirstOrDefault();
        }

        public async Task<List<UserContact>> GetUserContactsAsync(int userId)
        {
            return (await _userContactRepository.GetAllAsync(x => x.User.Id == userId)).ToList();
        }

        public async Task<List<UserContact>> GetUserContactsAsync(int userId, int groupId)
        {
            var mapping = await (await _userContactGroupMappingRepository.GetAllAsync(x => x.Group.Id == groupId)).Select(x => x.Contact.Id).ToListAsync();
            return (await _userContactRepository.GetAllAsync(x => x.User.Id == userId && mapping.Contains(x.Id))).ToList();
        }

        public async Task<UserGroup> GetUserGroupByIdAsync(int id)
        {
            return (await _userGroupRepository.GetAllAsync(x => x.Id == id))
                .Include(x => x.ContactMapping)
                .FirstOrDefault();
        }

        public async Task<List<UserGroup>> GetUserGroupsAsync(int userId)
        {
            return (await _userGroupRepository.GetAllAsync(x => x.User.Id == userId)).ToList();
        }

        public async Task InsertOrUpdateUserContactAsync(ContactModel model)
        {
            if (model.Id > 0)
            {
                var contact = await GetUserContactByIdAsync(model.Id);
                if (contact != null)
                {
                    var mappings = await _userContactGroupMappingRepository.GetAllAsync(x => x.Contact.Id == model.Id);
                    await _userContactGroupMappingRepository.DeleteAllAsync(await mappings.ToListAsync());
                    var list = new List<UserContactGroupMapping>();
                    foreach (var groupId in model.GroupIds)
                    {
                        list.Add(new UserContactGroupMapping()
                        {
                            Contact = contact,
                            Group = await _userGroupRepository.GetByIdAsync(groupId)
                        });
                    }
                    contact.Address = model.Address;
                    contact.Name = model.Name;
                    contact.GroupMapping = list;
                    await _userContactRepository.UpdateAsync(contact);
                }
                else
                    throw new Exception(StringResources.RecordNotExists);
            }
            else
            {
                var groupList = await GetUserGroupByIdsAsync(model.GroupIds);
                var insertedContact = new UserContact()
                {
                    Address = model.Address,
                    Name = model.Name,
                    User = await _applicationUser.GetCurrentUserAsync()
                };
                await _userContactRepository.InsertAsync(insertedContact);
                var list = new List<UserContactGroupMapping>();
                foreach (var group in groupList)
                {
                    list.Add(new UserContactGroupMapping()
                    {
                        Contact = insertedContact,
                        Group = group
                    });
                }
                insertedContact.GroupMapping = list;
                await _userContactRepository.UpdateAsync(insertedContact);
                model.Id = insertedContact.Id;
            }
        }

        public async Task InsertOrUpdateUserGroupAsync(UserGroupModel model)
        {
            if (model.Id > 0)
            {
                var group = await GetUserGroupByIdAsync(model.Id);
                var GroupExists = await CheckIfGroupNameExistsAsync(model.Id, model.Name);
                if (GroupExists)
                    throw new Exception(StringResources.GroupNameAllreadyExists);
                if (group != null)
                {
                    group.UpdatedOnUTC = DateTime.UtcNow;
                    group.Name = model.Name;
                    var list = new List<UserContactGroupMapping>();
                    foreach (var contact in await GetUserContactByIdsAsync(model.ContactIds.Where(x => x.HasValue).Select(x => (int)x).ToList()))
                    {
                        list.Add(new UserContactGroupMapping()
                        {
                            Contact = contact,
                            Group = group
                        });
                    }
                    group.ContactMapping = list;
                    var mappings = await _userContactGroupMappingRepository.GetAllAsync(x => x.Group.Id == model.Id);
                    await _userContactGroupMappingRepository.DeleteAllAsync(await mappings.ToListAsync());
                    await _userGroupRepository.UpdateAsync(group);
                }
                else
                {
                    throw new Exception(StringResources.RecordNotExists);
                }
            }
            else
            {
                var GroupExists = await CheckIfGroupNameExistsAsync(model.Id, model.Name);
                if (GroupExists)
                    throw new Exception(StringResources.GroupNameAllreadyExists);
                var insertedGroup = new UserGroup()
                {
                    CreatedOnUTC = DateTime.UtcNow,
                    UpdatedOnUTC = DateTime.UtcNow,
                    Name = model.Name,
                    User = await _applicationUser.GetCurrentUserAsync()
                };
                await _userGroupRepository.InsertAsync(insertedGroup);
                var list = new List<UserContactGroupMapping>();
                foreach (var contact in await GetUserContactByIdsAsync(model.ContactIds.Where(x => x.HasValue).Select(x => (int)x).ToList()))
                {
                    list.Add(new UserContactGroupMapping()
                    {
                        Contact = contact,
                        Group = insertedGroup
                    });
                }
                insertedGroup.ContactMapping = list;
                await _userGroupRepository.UpdateAsync(insertedGroup);
                model.Id = insertedGroup.Id;
            }
        }



        public async Task<List<UserContact>> GetUserContactByIdsAsync(List<int> ids)
        {
            return (await _userContactRepository.GetAllAsync(x => ids.Contains(x.Id))).ToList();
        }

        public async Task<List<UserGroup>> GetUserGroupByIdsAsync(List<int> ids)
        {
            return (await _userGroupRepository.GetAllAsync(x => ids.Contains(x.Id))).ToList();
        }

        public async Task<IPagedList<UserContact>> GetPagedListUserContactAsync(int userId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await ((await _userContactRepository.GetAllAsync(x => x.User.Id == userId)).Include(x => x.GroupMapping).ToPagedListAsync(pageIndex, pageSize));
        }
        public async Task<IPagedList<UserGroup>> GetPagedListUserGroupAsync(int userId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await ((await _userGroupRepository.GetAllAsync(x => x.User.Id == userId))
                .Include(x => x.ContactMapping)
                .ToPagedListAsync(pageIndex, pageSize));
        }
        public async Task<List<int>> GetContactMappingGroupIds(int contactId)
        {
            return (await _userContactGroupMappingRepository.GetAllAsync(x => x.Contact.Id == contactId))
                 .Select(x => x.Group.Id)
                 .ToList();
        }

        public async Task<List<int>> GetContactMappingContactIdsAsync(int groupId)
        {
            return (await _userContactGroupMappingRepository.GetAllAsync(x => x.Group.Id == groupId))
                .Select(x => x.Contact.Id)
                .ToList();
        }

        private async Task<bool> CheckIfGroupNameExistsAsync(int id, string name)
        {
            var currentUser = await _applicationUser.GetCurrentUserAsync();
            if (id > 0)
                return (await _userGroupRepository.GetAllAsync(x => x.Id != id && x.Name == name && x.User.Id == currentUser.Id)).Any();
            return (await _userGroupRepository.GetAllAsync(x => x.Name == name && x.User.Id == currentUser.Id)).Any();
        }

        public async Task<UserContact> GetByAddress(string Address)
        {
            var userContact = (await _userContactRepository.GetAllAsync(x => x.Address == Address)).FirstOrDefault();
            if(userContact != null)
            {
                return userContact;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UserContact>> GetByUserId(int userId)
        {
            return await(await _userContactRepository.GetAllAsync(x => x.User.Id == userId)).ToListAsync();
        }
    }
}
