using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Investment
{    
    /// <summary>
    /// Represents a investment list model
    /// </summary>
    public partial record InvestmentListModel : BasePagedListModel<InvestmentModel>
    {
    }
}
