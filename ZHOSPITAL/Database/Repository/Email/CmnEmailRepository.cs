using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
//using System.Web.Helpers;
using ZHOSPITAL.Database.Interface.Email;
using ZHOSPITAL.Database.Interface.SMS;
using ZHOSPITAL.Models.Setup;
using static System.Net.WebRequestMethods;

namespace ZHOSPITAL.Database.Repository.Email
{
    public class CmnEmailepository : ICmnEmail
    {
        public CmnEmailepository() { }

        public async Task<bool> SendMail(CmnEmailCredential cmnEmailCredential)
        {

            var shopName = "My-Z-Bazar";
            var email = "zohurulcse10@gmail.com";

            try
            {
                var mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(email, shopName);
                if (cmnEmailCredential.MailCC != null && cmnEmailCredential.MailCC != "")
                {
                    mail.CC.Add(cmnEmailCredential.MailCC);
                }
                if (cmnEmailCredential.MailBCC != null && cmnEmailCredential.MailBCC != "")
                {
                    mail.Bcc.Add(cmnEmailCredential.MailBCC);
                }
                mail.Subject = cmnEmailCredential.MailSubject;
                mail.Body = cmnEmailCredential.MessageDetails;
                mail.IsBodyHtml = true;

                //Attachment attachment = new Attachment(strPath);
                //mail.Attachments.Add(attachment);

                if (EmailIsValid(email) == true)
                {
                    using (var smtp = new SmtpClient())
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                        smtp.UseDefaultCredentials = (bool)cmnEmailCredential.IsDefaultCredentials;
                        smtp.Timeout = 25000;
                        smtp.Host = cmnEmailCredential.SmtpHost;
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        System.Net.ServicePointManager.Expect100Continue = false;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                        smtp.Credentials = new System.Net.NetworkCredential(cmnEmailCredential.MailFrom, cmnEmailCredential.Passwords);
                        mail.Priority = MailPriority.High;
                        smtp.Port = (int)cmnEmailCredential.SmtpPort;
                        smtp.EnableSsl = (bool)cmnEmailCredential.EnableSsl;
                        if (cmnEmailCredential.IsSecurityProtocol == true)
                        {
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        }
                        await smtp.SendMailAsync(mail);
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SendOTPMail(string email, int otp, CmnEmailCredential cmnEmailCredential)
        {
            var shopName = "My-Z-Bazar";
            
            try
            {
                var mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(email, shopName);
                if (cmnEmailCredential.MailCC != null && cmnEmailCredential.MailCC != "")
                {
                    mail.CC.Add(cmnEmailCredential.MailCC);
                }
                if (cmnEmailCredential.MailBCC != null && cmnEmailCredential.MailBCC != "")
                {
                    mail.Bcc.Add(cmnEmailCredential.MailBCC);
                }
                mail.Subject = cmnEmailCredential.MailSubject;
                mail.Body = cmnEmailCredential.MessageDetails;
                mail.IsBodyHtml = true;

                //Attachment attachment = new Attachment(strPath);
                //mail.Attachments.Add(attachment);

                if (EmailIsValid(email) == true)
                {
                    using (var smtp = new SmtpClient())
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                        smtp.UseDefaultCredentials = (bool)cmnEmailCredential.IsDefaultCredentials;
                        smtp.Timeout = 25000;
                        smtp.Host = cmnEmailCredential.SmtpHost;
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        System.Net.ServicePointManager.Expect100Continue = false;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                        smtp.Credentials = new System.Net.NetworkCredential(cmnEmailCredential.MailFrom, cmnEmailCredential.Passwords);
                        mail.Priority = MailPriority.High;
                        smtp.Port = (int)cmnEmailCredential.SmtpPort;
                        smtp.EnableSsl = (bool)cmnEmailCredential.EnableSsl;
                        if (cmnEmailCredential.IsSecurityProtocol == true)
                        {
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        }
                        await smtp.SendMailAsync(mail);
                    }

                }

                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
            
        }

        public bool EmailIsValid(string email)
        {
            Regex _Regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,9}|[0-9]{1,3})(\]?)$");

            string[] _emails = email.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string em in _emails)
            {
                if (!_Regex.IsMatch(em))
                    return false;
            }
            return true;
        }
    }
}