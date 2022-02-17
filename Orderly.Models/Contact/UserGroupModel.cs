using Orderly.Helpers;
using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Contact
{
    public record UserGroupModel : BaseEntityModel
    {
        public UserGroupModel()
        {
            ContactIds = new List<int?>();
        }
        [Required(ErrorMessage = StringResources.NameRequiredValidatonError)]
        public string Name { get; set; }
        public List<int?> ContactIds { get; set; }
    }
    
}
