using Orderly.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Portfolio
{
    public class TransactionLinkValidationModel : BaseApiValidationModel
    {
        public ResultStatus result { get; set; } = new ResultStatus();
    }
    public class ResultStatus
    {
        public RequestStatus? status { get; set; }
    }
}
