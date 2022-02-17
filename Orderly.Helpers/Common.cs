using System.Net;
using System.Net.Mail;

namespace Orderly.Helpers
{
    public static class Common
    {
        public static string LinkExpiryTime { get; set; }
        public static string EncryptionKey { get; set; }
        public static string SystemEmail { get; set; }
        public static string SystemPassword { get; set; }
        public static string Port { get; set; }
        public static string Host { get; set; }
        public static string MonitorCronExpression { get; set; }
        public static bool IsTGEMonitorNeedToRun { get; set; }
        public static bool IsOTCNeedToArchive { get; set; }
        public static int OTCArchiveInHours { get; set; }
        public static string Environment { get; set; }
        public static string WebsiteUrl { get; set; }

        public static void SendEmail(string emailTo, string body, string subject)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("info@digisoftsolution.net", "BreakingBad4@");
            smtp.Host = "smtppro.zoho.com";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("info@digisoftsolution.net");
            mail.To.Add(new MailAddress(emailTo));

            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = body.ToString();
            smtp.Send(mail);
            //return Ok(new { Success = true });
        }

        /// <summary>
        /// Resolves the Dependency on the basis of key
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <param name="key">Used at the time of registering the service</param>
        /// <returns></returns>
        public delegate T ServiceResolver<T>(string key) where T : class;

    }
}
