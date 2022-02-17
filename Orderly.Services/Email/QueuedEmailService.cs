using Orderly.Core.Domain.Common;
using Orderly.Helpers;
using Orderly.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Services.Email
{
    public class QueuedEmailService : IQueuedEmailService
    {
        #region Properties
        private readonly IRepository<QueuedEmail> _queuedEmailRepostiry;
        #endregion

        #region Constructor
        public QueuedEmailService(IRepository<QueuedEmail> queuedEmailRepostiry)
        {
            _queuedEmailRepostiry = queuedEmailRepostiry;
        }
        #endregion

        private async Task<List<QueuedEmail>> GetAllQueuedEmails()
        {
            return (await _queuedEmailRepostiry.GetAllAsync(x => !x.Sent))
                 .OrderBy(x => x.Priority)
                 .ThenBy(x => x.Id).ToList();
        }

        public async Task Insert(string to, string subject, string bcc, string body, int priority, string from = null, string token = null, bool isTGE = false)
        {
            if (string.IsNullOrEmpty(from))
            {
                from = Common.SystemEmail;
            }

            if (isTGE && !string.IsNullOrEmpty(token))
            {
                var allreadySent = (await _queuedEmailRepostiry.GetAllAsync(x => x.IsTGEMail && x.Token == token)).Any();
                if(allreadySent)
                return;
            }
            try
            {
                await _queuedEmailRepostiry.InsertAsync(new QueuedEmail()
                {
                    Bcc = bcc,
                    Body = body,
                    FailedTries = 0,
                    From = from,
                    IsTGEMail = isTGE,
                    Priority = priority,
                    Sent = false,
                    SentOn = null,
                    Subject = subject,
                    To = to,
                    Token = token,
                    TriedToSendOn = null
                });
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            
        }

        public async Task ProcessAllQueuedEmails()
        {
            var queue = await GetAllQueuedEmails();
            foreach(var mail in queue)
            {
                try
                {
                    Common.SendEmail(mail.To, mail.Body, mail.Subject);
                    mail.Sent = true;
                    mail.SentOn = DateTime.UtcNow;
                    mail.TriedToSendOn = DateTime.UtcNow;
                }
                catch(Exception ex)
                {
                    mail.Sent = false;                    
                    mail.TriedToSendOn = DateTime.UtcNow;
                }
                await _queuedEmailRepostiry.UpdateAsync(mail);
            }
        }

        public async Task<bool> IsEmailSent(string toEmail, string address)
        {
            bool isSent = false;
            var existingEmail = (await _queuedEmailRepostiry.GetAllAsync(x => x.To.ToLower().Trim() == toEmail.ToLower().Trim()
            && x.Token.ToLower().Trim() == address.Trim().ToLower() && x.IsTGEMail)).FirstOrDefault();
            if(existingEmail != null)
            {
                isSent = true;
            }
            return isSent;
        }
    }
}
