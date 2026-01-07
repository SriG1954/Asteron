using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Helper
{
    public class MailClient
    {
        private string _senderEmail = null!;
        private string _recipientEmail = null!;
        private string _subject = null!;
        private string _mailBody = null!;

        public MailClient(string SenderEmail, string RecipientEmail, string Subject, string MailBody )
        {
            _senderEmail = SenderEmail;
            _recipientEmail = RecipientEmail;
            _subject = Subject;
            _mailBody = MailBody;
        }

        public async Task<bool> Send()
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();
            bool create = false;

            try
            {
                if (_recipientEmail.Contains("_"))
                {
                    string[] _senderaddress = _recipientEmail.Split('_');
                    if (_senderaddress != null && _senderaddress.Count() > 0)
                    {
                        _recipientEmail = _senderaddress[0];
                    }
                }

                // Set the subject, sender and receipient address of the mail message
                mMailMessage.Subject = _subject;
                mMailMessage.From = new MailAddress(_senderEmail);
                mMailMessage.To.Add(new MailAddress(_recipientEmail));

                // Set the body of the mail message
                mMailMessage.Body = _mailBody;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = true;

                // Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;

                using (SmtpClient mSmtpClient = new SmtpClient("mailrelay.wlife.com.au", 25))
                {
                    // Set credentials
                    mSmtpClient.EnableSsl = true;
                    // Send the mail message
                    await mSmtpClient.SendMailAsync(mMailMessage);
                }

                create = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                create = false;
            }
            finally
            {
                if (mMailMessage != null)
                {
                    mMailMessage.Dispose();
                    mMailMessage = null!;
                }
            }

            return create;
        }
    }
}
