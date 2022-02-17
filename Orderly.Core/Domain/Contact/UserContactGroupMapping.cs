using Orderly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Contact
{
    public class UserContactGroupMapping : BaseEntity
    {
        public virtual UserContact Contact { get; set; }
        public virtual UserGroup Group { get; set; }
    }
}
