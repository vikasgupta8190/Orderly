using Orderly.Models.Enums;

namespace Orderly.Models.Portfolio
{
    public class BaseApiValidationModel
    {
        public RequestStatus status { get; set; }
        public string message { get; set; }
    }
}