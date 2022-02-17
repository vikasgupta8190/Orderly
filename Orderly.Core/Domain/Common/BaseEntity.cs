using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Core.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
