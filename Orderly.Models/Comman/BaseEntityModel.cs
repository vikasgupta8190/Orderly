using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Comman
{
    public partial record BaseEntityModel : BaseOrderlyModel
    {
        public int Id { get; set; }
    }
}
