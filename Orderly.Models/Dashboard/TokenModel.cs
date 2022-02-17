using Orderly.Models.Comman;
using System;

namespace Orderly.Models.Dashboard
{
    public record TokenModel:BaseEntityModel
    {
        public string TokenValue { get; set; }
        public string TokenName { get; set; }
        public DateTime TokenDate { get; set; }
        public int LeftTime { get; set; }
    }
}
