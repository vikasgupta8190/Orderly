using Microsoft.AspNetCore.Mvc.Rendering;

using Orderly.Helpers;
using Orderly.Models.Comman;

using System.Collections.Generic;
using System.ComponentModel;

namespace Orderly.Models.OTC
{
    public record OTCModel : BaseEntityModel
    {

        [DisplayName(ModelComponenteNames.OTCType)]
        public string Type { get; set; }
        public List<SelectListItem> TypeList { get; set; }
        [DisplayName(ModelComponenteNames.TokenId)]
        public int TokenId { get; set; }
        public List<SelectListItem> TokenList { get; set; }

        [DisplayName(ModelComponenteNames.Quantity)]
        public int TokenQty { get; set; }
        [DisplayName(ModelComponenteNames.Lockup)]
        public decimal Lockup { get; set; }
        [DisplayName(ModelComponenteNames.Vesting)]
        public decimal Vesting { get; set; }
        [DisplayName(ModelComponenteNames.PricePerToken)]
        public decimal PricePerToken { get; set; }
        [DisplayName(ModelComponenteNames.TotalAmount)]
        public decimal TotalAmount { get; set; }
        [DisplayName(ModelComponenteNames.Currency)]
        public string Currency { get; set; }
        [DisplayName(ModelComponenteNames.ContactDetails)]
        public string ContactDetails { get; set; }
        [DisplayName(ModelComponenteNames.TelegramUsername)]
        public string TelegramUsername { get; set; }
        [DisplayName(ModelComponenteNames.Email)]
        public string Email { get; set; }
        public string TokenUrl { get; set; }
        public string TokenName { get; set; }
        public string TokenAddress { get; set; }
        public string NetworkUrl { get; set; }
    }

    public record OTCListModel : BasePagedListModel<OTCModel>
    {

    }
}
