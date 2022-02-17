using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Contact
{
    public record GridContactModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        public string GroupName { get; set; }
    }

    public record ContactListModel : BasePagedListModel<GridContactModel>
    {

    }
}
