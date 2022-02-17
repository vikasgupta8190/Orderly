using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Contact
{
    public record GridGroupModel : BaseEntityModel
    {
        public string Name { get; set; }
        public List<GridContactModel> Contacts { get; set; } = new List<GridContactModel>();
    }
    public record GroupListModel : BasePagedListModel<GridGroupModel>
    {
    }
}
