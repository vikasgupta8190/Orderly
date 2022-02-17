using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Comman
{
    /// <summary>
    /// Represents a paged model
    /// </summary>
    public partial interface IPagedModel<T> where T : BaseOrderlyModel
    {
    }
}
