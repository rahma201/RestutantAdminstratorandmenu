using System.Net.Mail;
using System.Net;
using Pro2.View_Models;

namespace Pro2.Helpers.Email
{

    public class EmailHelper : IEmailHelper
    {
        //public void SendEmail(ContactEmailViewModel model)
        //{
        //    var Password = "cgub rqck kaji sbdp";  
        //    var Email = "rahmashelbaye@gmail.com";  
        //    var Server = "smtp.gmail.com";  
        //    var Port = 587; 

        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //    SmtpClient smtpClient = new SmtpClient(Server, Port);
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.EnableSsl = true;  
        //    smtpClient.Credentials = new NetworkCredential(Email, Password);

        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress(Email);
        //    mailMessage.Subject = model.Subject;
        //    mailMessage.To.Add(model.Email);
        //    mailMessage.IsBodyHtml = true;
        //    mailMessage.Body = ConvertBodyToHTML(model.Message);

           
        //    smtpClient.Send(mailMessage);
        //}

        private string ConvertBodyToHTML(string message)
        {
            var htmlMessage = @$"
        <h1 style='color:red'>
        {message}
        </h1>
    ";

            return htmlMessage;
        }

    }
}
