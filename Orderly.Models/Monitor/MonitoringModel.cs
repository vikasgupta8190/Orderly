using Microsoft.AspNetCore.Mvc.Rendering;
using Orderly.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Monitor
{
    public class MonitorModel
    {
        public MonitorModel()
        {
            AvailableAddresses = new List<SelectListItem>();
        }

        public int[] ids { get; set; }
        public List<SelectListItem> AvailableAddresses { get; set; }        
    }

    public record MonitoringModel : BaseEntityModel
    {        
        public int[] AddressIds { get; set; }
        public bool Notification { get; set; }
        public bool ShowInPortfolio { get; set; }
        public string Addresses { get; set; }
        public string Token { get; set; }
        public bool IncommingTokenNotificationEvent { get; set; }
        public bool TokenGenerationNotificationEvent { get; set; }
    }

    public record MonitoringListModel : BasePagedListModel<MonitoringModel>
    {       
        public bool EnableIncommingTokenNotification { get; set; }
        public bool ShowPortfolio { get; set; }
    }
}
