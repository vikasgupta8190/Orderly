using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Tokens
{
    public record TokenSearchModel : BaseSearchModel
    {
        public int NetworkId { get; set; }
    }
}
