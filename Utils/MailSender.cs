using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Utils
{
    public class MailSender
    {
        private string User;
        private string Password;

        public void sendMail(string From, string To, string Subject, string Body)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(User, Password),
                    EnableSsl = true
                };
                MailMessage msg = new MailMessage(From, To, Subject, Body);
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MailSender(string _User, string _Password)
        {
            User = _User;
            Password = _Password;
        }
    }
}
