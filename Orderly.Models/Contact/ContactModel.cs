using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Helpers;
using Orderly.Models.Comman;
using Orderly.Models.Distributor;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Contact
{
    public partial record ContactModel : BaseEntityModel
    {
        public ContactModel()
        {
            AvailableGroups = new List<SelectListItem>();
            SearchModel = new TransactionDetailSearchModel();
            GroupIds = new List<int>();
        }
        [Required(ErrorMessage = StringResources.NameRequiredValidatonError)]
        public string Name { get; set; }
        [DisplayName(ModelComponenteNames.ShowGroup)]
        public bool ShowGroup { get; set; } = false;
        public string Address { get; set; }
        [DisplayName(ModelComponenteNames.GroupIds)]
        public List<int> GroupIds { get; set; }
        public List<SelectListItem> AvailableGroups { get; set; }
        public TransactionDetailSearchModel SearchModel { get; set; }
    }
}
