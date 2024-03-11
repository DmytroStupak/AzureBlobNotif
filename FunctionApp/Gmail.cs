using System.Net.Mail;
using System.Net;
using AzureBlobNotif.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AzureBlobNotif
{
    public class Gmail : IGmail
    {
        public bool Send(string fileName, string sasUri)
        {
            var email = fileName.Split(',')[0];
            var em = new EmailAddressAttribute();

            if (em.IsValid(email))
            {
                MailAddress from = new MailAddress("email", "Dmytro");
                MailAddress to = new MailAddress(email);
                MailMessage m = new MailMessage(from, to);

                m.Subject = "File uploaded";
                m.Body = $"<h2>File \"{fileName.Split(',')[1]}\" uploaded successfully</h2> <a href=\"{sasUri}\">File</a> <p>Your file will be available for downloading for 1 hour</p>";
                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("email", "password");
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(m);

                return true;
            }
            else return false;
        }
    }
}
