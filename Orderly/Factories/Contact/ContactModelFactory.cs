using Microsoft.AspNetCore.Mvc.Rendering;
using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Contact;
using Orderly.Helpers;
using Orderly.Models.Contact;
using Orderly.Models.Distributor;
using Orderly.Models.Extensions;
using Orderly.Services.Contact;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Contact
{
    public class ContactModelFactory : IContactModelFactory
    {
        #region properties
        private readonly IApplicationUser _appUser;
        private readonly IContactService _contactService;
        private readonly IPortfolioMonitoringService _portfolioMonitoringService;
        private readonly INetworkTokenService _networkTokenService;
        #endregion

        #region Constructor
        public ContactModelFactory(IApplicationUser appUser,
            IContactService contactService,
            IPortfolioMonitoringService portfolioMonitoringService,
            INetworkTokenService networkTokenService)
        {
            _appUser = appUser;
            _contactService = contactService;
            _networkTokenService = networkTokenService;
            _portfolioMonitoringService = portfolioMonitoringService;
        }


        #endregion

        #region Methods
        public async Task<ContactModel> PrepareContactModelAsync(int id = 0)
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            var retVal = new ContactModel();
            List<SelectListItem> availableTokens = new List<SelectListItem>();
            availableTokens.Add(new SelectListItem()
            {
                Text = StringResources.AllTokens,
                Value = "0"
            });
            retVal.SearchModel = new TransactionDetailSearchModel()
            {
                AvailableTokensTypes = availableTokens
            };
            retVal.SearchModel.AvailableTokensTypes.AddRange(
                (await _networkTokenService.GetAll())
                .Select(x => new SelectListItem()
                {
                    Text = string.Format("{0} ({1})", x.Address, x.Name),
                    Value = x.Id.ToString(),                    
                }));
            retVal.SearchModel.FilterType = "All";
            retVal.AvailableGroups = (await _contactService.GetUserGroupsAsync(currentUser.Id)).Select(v => new SelectListItem()
            {
                Text = v.Name,
                Value = v.Id.ToString()
            }).ToList();
            if (id <= 0)
                return retVal;
            var userContact = await _contactService.GetUserContactByIdAsync(id);
            retVal.Address = userContact.Address;
            retVal.GroupIds = (await _contactService.GetContactMappingGroupIds(userContact.Id));
            retVal.Name = userContact.Name;
            retVal.Id = userContact.Id;

            retVal.AvailableGroups = retVal.AvailableGroups
                .Select(l => new SelectListItem
                {
                    Selected = (retVal.GroupIds.Contains(Convert.ToInt32(l.Value))),
                    Text = l.Text,
                    Value = l.Value
                }).ToList();
            return retVal;
        }

        public async Task<List<ContactModel>> PrepareContactModelListAsync()
        {
            var currentUser = await _appUser.GetCurrentUserAsync();
            return currentUser.Contacts.Select(x => new ContactModel()
            {
                Address = x.Address,
                AvailableGroups = (_contactService.GetUserGroupsAsync(currentUser.Id).Result).Select(v => new SelectListItem()
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                }).ToList(),
                Id = x.Id,
                Name = x.Name,
                //GroupId = x.Group.Id
            }).ToList();
        }

        public async Task<ContactListModel> PrepareContactListModelAsync(ContactSearchModel searchModel)
        {
            var contacts = await _contactService.GetPagedListUserContactAsync((await _appUser.GetCurrentUserAsync()).Id, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            return new ContactListModel().PrepareToGrid(searchModel, contacts, () =>
            {
                return contacts.Select(x =>
                {
                    return new GridContactModel()
                    {
                        Address = x.Address,
                        Id = x.Id,
                        Name = x.Name,
                        Token = string.Empty
                    };
                });
            });
        }

        public async Task<GroupListModel> PrepareGroupListModelAsync(ContactSearchModel searchModel)
        {
            var contacts = await _contactService.GetPagedListUserGroupAsync((await _appUser.GetCurrentUserAsync()).Id, searchModel.Page - 1, searchModel.PageSize);
            //prepare list model
            return new GroupListModel().PrepareToGrid(searchModel, contacts, () =>
            {
                return contacts.Select(x =>
                {
                    return new GridGroupModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Contacts = GetContacts(x).Result
                    };
                });
            });
        }

        public async Task<GridGroupModel> PrepareGroupModelAsync(int id)
        {
            var retVal = new GridGroupModel();
            if (id <= 0)
                return retVal;
            var group = await _contactService.GetUserGroupByIdAsync(id);
            if (group != null)
            {
                retVal.Name = group.Name;
                retVal.Id = group.Id;
                retVal.Contacts = (await _contactService.GetContactMappingContactIdsAsync(group.Id)).Select(x => new GridContactModel()
                {
                    Id = x
                }).ToList();
            }
            return retVal;
        }
        #endregion

        #region Utitlities
        private async Task<List<GridContactModel>> GetContacts(UserGroup group)
        {
            var contacts = await _contactService.GetUserContactsAsync((await _appUser.GetCurrentUserAsync()).Id, group.Id);
            return contacts.Select(x => new GridContactModel()
            {
                Address = x.Address,
                Id = x.Id,
                Name = x.Name,
                Token = string.Empty
            }).ToList();
        }
        #endregion
    }
}
