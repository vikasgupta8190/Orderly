using Orderly.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly.Factories.Contact
{
    public interface IContactModelFactory
    {
        Task<ContactModel> PrepareContactModelAsync(int id = 0);
        Task<List<ContactModel>> PrepareContactModelListAsync();
        Task<ContactListModel> PrepareContactListModelAsync(ContactSearchModel searchModel);
        Task<GroupListModel> PrepareGroupListModelAsync(ContactSearchModel searchModel);
        Task<GridGroupModel> PrepareGroupModelAsync(int id);
    }
}
