using Microsoft.AspNetCore.Builder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderly
{
    public static class RouteProvider
    {
        public static void RegisterRoutes(this IApplicationBuilder app)
        {

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                #region Account Controller Routes
                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "login",
                    defaults: new { controller = "Account", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "RegisterAccount",
                    pattern: "register",
                    defaults: new { controller = "Account", action = "Register" });

                endpoints.MapControllerRoute(
                    name: "Logout",
                    pattern: "sign-out",
                    defaults: new { controller = "Account", action = "Logout" });

                endpoints.MapControllerRoute(
                    name: "Signup",
                    pattern: "sign-up",
                    defaults: new { controller = "Account", action = "SignUp" });

                endpoints.MapControllerRoute(
                    name: "SignupConfirmation",
                    pattern: "sign-up-confirmation",
                    defaults: new { controller = "Account", action = "SignupConfirmation" });

                endpoints.MapControllerRoute(
                    name: "ForgotPassword",
                    pattern: "forgot-password",
                    defaults: new { controller = "Account", action = "ForgotPassword" });

                endpoints.MapControllerRoute(
                    name: "ForgotPasswordConfirmation",
                    pattern: "forgot-password-confirmation",
                    defaults: new { controller = "Account", action = "ForgotPasswordConfirmation" });

                endpoints.MapControllerRoute(
                    name: "ResetPasswordConfirmation",
                    pattern: "reset-password-confirmation",
                    defaults: new { controller = "Account", action = "ResetPasswordConfirmation" });

                endpoints.MapControllerRoute(
                    name: "ResetPassword",
                    pattern: "reset-password",
                    defaults: new { controller = "Account", action = "ResetPassword" });

                endpoints.MapControllerRoute(
                    name: "LinkExpiryTime",
                    pattern: "link-detail",
                    defaults: new { controller = "Account", action = "LinkExpiryTime" });

                endpoints.MapControllerRoute(
                    name: "SetupPortfolioMonitoring",
                    pattern: "setup-portfolio-monitoring",
                    defaults: new { controller = "Account", action = "SetupPortfolioMonitoring" });

                endpoints.MapControllerRoute(
                    name: "GetPortfolioCard",
                    pattern: "get-filter-portfolio-cards",
                    defaults: new { controller = "Account", action = "GetPortfolioCard" });

                endpoints.MapControllerRoute(
                    name: "SendEmailVerificationLink",
                    pattern: "send-email-verification-link",
                    defaults: new { controller = "Account", action = "SendEmailVerificationLink" });
                #endregion
                #region Home Controller Routes
                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "dashboard",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "SetupPortfolio",
                    pattern: "dashboard-portfolio",
                    defaults: new { controller = "Home", action = "SetupPortfolio" });

                endpoints.MapControllerRoute(
                    name: "GetWalletUpcomingToken",
                    pattern: "wallet-upcoming-token",
                    defaults: new { controller = "Home", action = "GetToken" });

                endpoints.MapControllerRoute(
                    name: "GetTokenOverview",
                    pattern: "get-token-overview",
                    defaults: new { controller = "Home", action = "GetTokenOverView" });


                    endpoints.MapControllerRoute(
                    name: "GetPieChartData",
                    pattern: "get-pie-chart-data",
                    defaults: new { controller = "Home", action = "GetPieChartData" });


                #endregion
                #region Investment Controller Routes
                endpoints.MapControllerRoute(
                    name: "InvestmentManager",
                    pattern: "investment-manager",
                    defaults: new { controller = "Investment", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "GetInvestments",
                    pattern: "investment-list",
                    defaults: new { controller = "Investment", action = "GetInvestments" });

                endpoints.MapControllerRoute(
                    name: "TransactionLinkVerification",
                    pattern: "verify-investment-transaction-link",
                    defaults: new { controller = "Investment", action = "GetInvestedAmount" });

                endpoints.MapControllerRoute(
                    name: "EditInvestment",
                    pattern: "edit-investment",
                    defaults: new { controller = "Investment", action = "Edit" });

                endpoints.MapControllerRoute(
                    name: "GetContactDetails",
                    pattern: "get-contact-details",
                    defaults: new { controller = "Investment", action = "GetContactDetailByAddress" });

                #endregion
                #region Portfolio Controller Routes
                endpoints.MapControllerRoute(
                    name: "ShowAddressPopup",
                    pattern: "show-address-popup",
                    defaults: new { controller = "Portfolio", action = "ShowAddressPopup" });

                endpoints.MapControllerRoute(
                    name: "SavePortfolioMonitoring",
                    pattern: "post-portfolio-monitoring",
                    defaults: new { controller = "Portfolio", action = "SavePortfolioMonitoring" });

                endpoints.MapControllerRoute(
                    name: "SaveDistributorAddress",
                    pattern: "save-distributor-address",
                    defaults: new { controller = "Distributor", action = "SaveAddress" });

                endpoints.MapControllerRoute(
                    name: "DeletePortfolioMonitoring",
                    pattern: "delete-portfolio-monitoring",
                    defaults: new { controller = "Portfolio", action = "DeletePortfolioMonitoring" });

                endpoints.MapControllerRoute(
                    name: "UploadSaftFile",
                    pattern: "upload-saft-file",
                    defaults: new { controller = "Investment", action = "UploadSaftFile" });


                #endregion
                #region Distributor Controller Routes
                endpoints.MapControllerRoute(
                   name: "Distributor",
                   pattern: "distributor",
                   defaults: new { controller = "Distributor", action = "Index" });

                endpoints.MapControllerRoute(
                   name: "TransactionList",
                   pattern: "transaction-list",
                   defaults: new { controller = "Distributor", action = "List" });

                #endregion
                #region Calendar Controller Routes
                endpoints.MapControllerRoute(
                    name: "Calendar",
                    pattern: "calender",
                    defaults: new { controller = "Calendar", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "GetCalendar",
                    pattern: "get-calendar",
                    defaults: new { controller = "Calendar", action = "GetCalendarResults" });

                endpoints.MapControllerRoute(
                    name: "GetUpcomingToken",
                    pattern: "get-upcoming-token",
                    defaults: new { controller = "Calendar", action = "GetUpcomingToken" });

                #endregion
                #region Analyzer Controller Routes
                endpoints.MapControllerRoute(
                    name: "Analyzer",
                    pattern: "analyzer",
                    defaults: new { controller = "Analyzer", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "InvestmentAnalyerList",
                    pattern: "analyzer-investment-list",
                    defaults: new { controller = "Analyzer", action = "InvestmentAnalyerList" });

                endpoints.MapControllerRoute(
                    name: "DistributionTransactions",
                    pattern: "get-distribution-transactions",
                    defaults: new { controller = "Analyzer", action = "DistributionTransactions" });

                endpoints.MapControllerRoute(
                    name: "DistributionGridList",
                    pattern: "distribution-grid-list",
                    defaults: new { controller = "Analyzer", action = "InvestmentDistributionList" });

                endpoints.MapControllerRoute(
                    name: "FiltersData",
                    pattern: "filters-data",
                    defaults: new { controller = "Analyzer", action = "GetFiltersData" });

                endpoints.MapControllerRoute(
                    name: "GetChartData",
                    pattern: "get-chart-data",
                    defaults: new { controller = "Analyzer", action = "GetAnalyzerMapData" });
                #endregion
                #region Contacts Controller Routes
                endpoints.MapControllerRoute(
                    name: "Contacts",
                    pattern: "contacts",
                    defaults: new { controller = "Contacts", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "GetContacts",
                    pattern: "get-contact-list",
                    defaults: new { controller = "Contacts", action = "ContactList" });

                endpoints.MapControllerRoute(
                    name: "GetGroups",
                    pattern: "get-group-list",
                    defaults: new { controller = "Contacts", action = "GroupList" });

                endpoints.MapControllerRoute(
                    name: "DeleteContact",
                    pattern: "delete-contact",
                    defaults: new { controller = "Contacts", action = "DeleteContact" });

                endpoints.MapControllerRoute(
                    name: "DeleteGroup",
                    pattern: "delete-group",
                    defaults: new { controller = "Contacts", action = "DeleteGroup" });

                endpoints.MapControllerRoute(
                    name: "EditContact",
                    pattern: "edit-contact",
                    defaults: new { controller = "Contacts", action = "EditContact" });

                endpoints.MapControllerRoute(
                    name: "EditGroup",
                    pattern: "edit-group",
                    defaults: new { controller = "Contacts", action = "EditGroup" });


                #endregion
                #region Common Controller Routes
                endpoints.MapControllerRoute(
                    name: "NotificationMessage",
                    pattern: "notificationMessage",
                    defaults: new { controller = "Common", action = "GetNotificationHtml" });
                #endregion
                #region ManageTokens Controller Routes

                endpoints.MapControllerRoute(
                    name: "ManageTokens",
                    pattern: "manage-tokens",
                    defaults: new { controller = "TokenManagement", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "EditToken",
                    pattern: "edit-token",
                    defaults: new { controller = "TokenManagement", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "GetTokens",
                    pattern: "token-list",
                    defaults: new { controller = "TokenManagement", action = "GetTokens" });

                #endregion
                #region Monitoring Controller Routes

                endpoints.MapControllerRoute(
                  name: "Monitoring",
                  pattern: "monitoring",
                  defaults: new { controller = "Monitoring", action = "Index" });

                endpoints.MapControllerRoute(
                  name: "GetMonitroing",
                  pattern: "get-monitorings",
                  defaults: new { controller = "Monitoring", action = "GetMonitroing" });

                endpoints.MapControllerRoute(
                  name: "DeleteMonitoring",
                  pattern: "delete-monitoring",
                  defaults: new { controller = "Monitoring", action = "DeleteMonitoring" });

                endpoints.MapControllerRoute(
                  name: "UpdateNotification",
                  pattern: "update-notification",
                  defaults: new { controller = "Monitoring", action = "UpdateNotification" });

                endpoints.MapControllerRoute(
                  name: "UpdateShowOnPortfolio",
                  pattern: "update-show-on-portfolio",
                  defaults: new { controller = "Monitoring", action = "UpdateShowOnPortfolio" });

                endpoints.MapControllerRoute(
                  name: "TurnOnOffIncommingNotifications",
                  pattern: "turn-on-off-incomming-notifications",
                  defaults: new { controller = "Monitoring", action = "TurnOnOffIncommingNotifications" });

                endpoints.MapControllerRoute(
                 name: "TurnOnOffTokenGenerationNotifications",
                 pattern: "turn-on-off-token-generation-notifications",
                 defaults: new { controller = "Monitoring", action = "TurnOnOffTokenGenerationNotifications" });

                #endregion
                #region OTC Controller Routes 
                endpoints.MapControllerRoute(
                    name: "OTC",
                    pattern: "otc",
                    defaults: new { controller = "OTC", action = "Index" });
                
                endpoints.MapControllerRoute(
                    name: "GetOTCViewMode",
                    pattern: "otc-view",
                    defaults: new { controller = "OTC", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "GetOTC",
                    pattern: "otc-list",
                    defaults: new { controller = "OTC", action = "OTCList" });
               
                #endregion
                endpoints.MapRazorPages();
            });
        }
    }
}
