using Orderly.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Tokens
{
    public class Calendar : BaseEntity
    {
        public int TokenId { get; set; }
        public string Stage { get; set; }
        public DateTime Date { get; set; }      
        public decimal Goal { get; set; }
        public virtual NetworkToken Token { get; set; }
    }
}
