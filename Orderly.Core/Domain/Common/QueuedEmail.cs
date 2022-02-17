using System;

namespace Orderly.Core.Domain.Common
{
    public class QueuedEmail : BaseEntity
    {
        public int Priority { get; set; }
        public string From { get; set; }
        public string To { get; set; }        
        public string Bcc { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Token { get; set; }
        public int FailedTries { get; set; }
        public bool Sent { get; set; }
        public bool IsTGEMail { get; set; }
        public DateTime? SentOn { get; set; }
        public DateTime? TriedToSendOn { get; set; }       
    }
}
