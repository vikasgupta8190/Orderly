using System.Threading.Tasks;

namespace Orderly.Services.Email
{
    public interface IQueuedEmailService
    {
        /// <summary>
        /// This method will insert the email in queue
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="bcc"></param>
        /// <param name="body"></param>
        /// <param name="priority"></param>
        /// <param name="token"></param>
        /// <param name="isTGE"></param>
        /// <returns></returns>
        Task Insert(string to, string subject, string bcc, string body, int priority, string from = null, string token = null, bool isTGE = false);

        /// <summary>
        /// This method will process all the emails which are not sent yet
        /// </summary>
        Task ProcessAllQueuedEmails();
        Task<bool> IsEmailSent(string toEmail, string address);
    }
}
