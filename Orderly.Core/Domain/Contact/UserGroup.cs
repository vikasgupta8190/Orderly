using Microsoft.AspNetCore.Identity;
using Orderly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Contact
{
    public class UserGroup:BaseEntity
    {
        public UserGroup()
        {
            ContactMapping = new List<UserContactGroupMapping>();
        }
        public string Name { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
        public virtual ICollection<UserContactGroupMapping> ContactMapping { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
