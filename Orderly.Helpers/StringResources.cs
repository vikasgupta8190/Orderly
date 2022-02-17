using System;

namespace Orderly.Helpers
{
    #region String Resources
    public static class StringResources
    {
        #region Global
        public const string AddedSucessMessage = "Added Successfully !";
        public const string UpdateSuccessMessage = "Updated Successfully !";
        public const string DeleteMessage = "Deleted Successfully !";
        public const string GlobalRequiredValidatonError = "This field is required.";
        public const string DeleteConfirmationMessage = "Are you sure, you want to delete?";
        public const string Cancel = "Cancel";
        public const string Save = "Save";
        public const string Address = "Address";
        public const string Name = "Name";
        public const string Token = "Token";
        public const string Action = "Action";
        public const string GroupNameAllreadyExists = "Group Name Allready Exits ! Please try with another name.";
        public const string RecordNotExists = "No Record found !";
        public const string TokenManagement = "Manage Tokens";
        public const string AllChangeConfirmation = "Are you sure ? This action will make changes to all of the following data !";
        #endregion

        public const string AddNewContact = "Add New Contact";
        public const string EditContact = "Edit Contact";
        public const string Contact = "Contact";
        public const string AddAddressWithPlusSign = "+ Add Address";
        public const string AddGroupWithPlusSign = "+ Add Group";
        public const string AddNewGroup = "Add New Group";
        public const string EditGroup = "Edit Group";
        
        public const string Contacts = "Contacts";
        public const string InvestmentsManagerHeading = "Investment Manager";

        public const string AddNewInvestment = "Add New Investment";
        public const string General = "General";
        public const string VestingDetails = "Vesting Details";
        public const string DistributionType = "Distribution Type";
        public const string Distribution = "Distribution";
        public const string ConstructSchedule = "Construct Schedule";
        public const string Lockup = "Lockup";
        public const string NoLockup = "No Lockup";
        public const string LockupDuration = "Lockup Duration";
        public const string AddLockupWithPlusSign = "+ Add Lockup";
        public const string RemoveLockupWithMinusSign = "- Remove Lockup";
        public const string AddScheduleWithMinusSign = "+ Add Schedule";
        public const string AddWithMinusSign = "+ Add";
        public const string Period = "Month";
        public const string MonthPostFix = "Month";
        public const string InvestmentType = "Investment Type";
        public const string About = "About";
        public const string Days = "Days";
        public const string Months = "Months";
        public const string Years = "Year(s)";
        public const string DayValue = "1";
        public const string MonthValue = "2";
        public const string YearValue = "3";
        public const string FileNotFound = "File Not Found";


        public const string Portfolio = "Portfolio";
        public const string Monitoring = "Monitoring";
        public const string Analyzer = "Analyzer";
        public const string Distributor = "Distributor";
        public const string Calendar = "Calendar";
       
        public const string NameRequiredValidatonError = "Name is required please fill this field !";
        public const string ErrorMessage = "Sorry! an error occured. Please try again or contact to administrator.";
        public const string InvalidTransactionLink = "Transaction link is invalid";

        public const string TansactionHashCode = "Tx Hash";
        public const string Date = "Date";
        public const string From = "From";
        public const string To = "To";
        public const string Quantity = "Quantity";
        public const string AllTokens = "All Tokens";
        public const string NotVerifiedAddress = "Address {0} not verified Please check the address and try again";

        public const string DateUTC = "Date(UTC)";
        public const string InvestedAmount = "Amount Invested";
        public const string AmountOrPercentageOfLocked = "Amount / % of Locked";
        public const string Show = "Show";
        public const string ContactNotAvailable = "Contact is not available. Please first create the contact from Contact Page.";

        public const string AddNewToken = "Add New token";
        public const string ContractTokenNotValid = "Invalid token address";
        public const string AddMonitor = "Add Monitor";
        public const string AddNewMonitor = "Add New Monitoring";
        public const string AddMonitorInfoMessageHeading = "You have not setup monitoring yet";
        public const string AddMonitorInfoMessage = "Start monitoring network, token or full portfolio. Note we anonymize all data.";

        public const string OngoingToken = "Ongoing Token";
        public const string UpcomingToken = "Upcomming Token";
        public const string Stage = "Stage";
        public const string StartIn = "Start in";
        public const string EndIn = "Ends in";
        public const string Goal = "Goal";
        public const string Price = "Price";

        public const String UpcomingTokenUnlock = "Upcoming Token Unlocks";
        public const String Next30Days = "Next 30 Days";
        public const String OrderByTimeLeft = "Order By Time Left";

        public const string OTC = "OTC";
        public const String AddNewOTC = "Add New OTC";
    }
    #endregion

    #region Model Components Name
    public static class ModelComponenteNames
    {
        #region UserInvestmentModel Messages
        public const string WebsiteLink = "Website Link";
        public const string SaftFile = "SAFT File";
        public const string Address = "Address";
        public const string InvestmentTypes = "Investment Types";
        public const string DistributionTypes = "Distribution Types";
        public const string VestingPeriods = "Vesting Periods";
        public const string TokenPercentage = "Percentage Of Tokens";
        public const string Lockup = "Lockup";
        public const string InvestmentTransactionLink = "Investment Transaction Link";
        public const string InvestedAmount = "Amount Invested";
        public const string Sign = "Signee";
        public const string DistributionPortal = "Distribution Portal";
        public const string CustomLink = "Custom Link";
        public const string TokenId = "Token";
        public const string NumberOfToken = "Number Of Token";
        public const string FromAddress = "Funding Wallet";
        

        #endregion
        #region ContactModel Messages
        public const string ShowGroup = "Show Group Contacts";
        public const string GroupIds = "Group";
        #endregion
        #region Token Messages
        public const string InvestmentId = "Investment";
        #endregion

        #region OTCModel Messages
        public const string OTCType = "Type";
        public const string Quantity = "Token Amount";
        public const string Vesting = "Vesting";
        public const string PricePerToken = "Price Per Token";
        public const string TotalAmount = "Total Amount";
        public const string Currency = "Currency";
        public const string ContactDetails = "Contact Details";
        public const string TelegramUsername = "Telegram Username";
        public const string Email = "Email";
        #endregion

    }

    #endregion
}
