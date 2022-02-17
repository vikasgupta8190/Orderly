using Orderly.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Messages
{
    /// <summary>
    /// Message structure
    /// </summary>
    public struct NotifyData
    {
        /// <summary>
        /// Message type (success/warning/error)
        /// </summary>
        public NotifyType Type { get; set; }

        /// <summary>
        /// Message text
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Get a sets a value indicating whether the message should not be HTML encoded
        /// </summary>
        public bool Encode { get; set; }
    }
}
