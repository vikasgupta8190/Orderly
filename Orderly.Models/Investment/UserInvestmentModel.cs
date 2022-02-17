using Microsoft.AspNetCore.Mvc.Rendering;
using Orderly.Helpers;
using Orderly.Models.Comman;
using Orderly.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Orderly.Models.Investment
{
    public partial record UserInvestmentModel : BaseEntityModel
    {        
        public UserInvestmentModel()
        {
            AvailableNetworks = new List<SelectListItem>();
            AvailableVestingPeriods = new List<SelectListItem>();
            AvailableDistributionTypes = new List<SelectListItem>();
            AvailableInvestmentTypes = new List<SelectListItem>();
            AvailableContact = new List<SelectListItem>();
            AvailableToken = new List<SelectListItem>();
        }

        public int UserId { get; set; }
        public Guid? UniqueInvestmentId { get; set; }
        #region General
        public List<SelectListItem> AvailableNetworks { get; set; }
        [Required]
        public int NetworkId { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.InvestedAmount)]
        public decimal InvestedAmount { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.InvestmentTransactionLink)]
        public string InvestmentTransactionLink { get; set; }

        [DisplayName(ModelComponenteNames.Sign)]
        public string Sign { get; set; }

        public List<SelectListItem> AvailableContact { get; set; }
        public int? ContactId { get; set; }

        [DisplayName(ModelComponenteNames.NumberOfToken)]
        public int NumberOfToken { get; set; }

        public bool SignManually { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.DistributionPortal)]
        public string DistributionPortal { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.CustomLink)]
        public string CustomLink { get; set; }
        #endregion

        #region Vesting
        [Required]
        [DisplayName(ModelComponenteNames.Lockup)]
        public decimal VestingLockup { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.TokenPercentage)]
        public decimal VestingTokenPercentage { get; set; }

        [Required]
        public List<SelectListItem> AvailableVestingPeriods { get; set; }
        [DisplayName(ModelComponenteNames.VestingPeriods)]
        public int VestingId { get; set; }
        #endregion

        #region Distribution
        [Required]
        public List<SelectListItem> AvailableDistributionTypes { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.DistributionTypes)]
        public int DistributionTypeId { get; set; }
       
        public string Disributions { get; set; }
        public List<DistributionTypeModel> DistributionType { get; set; }
        #endregion

        #region Investment
        [Required]
        public List<SelectListItem> AvailableInvestmentTypes { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.InvestmentTypes)]
        public int InvestmentTypeId { get; set; }

        [Required]
        [DisplayName(ModelComponenteNames.Address)]
        public string Address { get; set; }
        #endregion

        #region About
        [DisplayName(ModelComponenteNames.SaftFile)]
        public string SaftFile { get; set; }
        public string SaftPathSavedFileName { get; set; }

        [Required]
        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$")]
        [DisplayName(ModelComponenteNames.WebsiteLink)]
        public string WebsiteLink { get; set; }
        public decimal RefundAmount { get; set; }
        public List<InvestmentSharedDetailViewModel> SharedInvestmentPersonDetail { get; set; }
        public string InvestmentQuantity { get; set; }
        [DisplayName(ModelComponenteNames.FromAddress)]
        public string FromAddress { get; set; }
        [DisplayName(ModelComponenteNames.TokenId)]
        public int? TokenId { get; set; }
        public List<SelectListItem> AvailableToken { get; set; }
        #endregion
    }
}
