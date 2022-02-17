using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Tokens
{
    public partial record TokenModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string NetworkName { get; set; }
    }
    public partial record TokenListModel : BasePagedListModel<TokenModel>
    {

    }
}
