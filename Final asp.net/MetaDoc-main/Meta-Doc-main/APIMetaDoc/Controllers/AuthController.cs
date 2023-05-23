using APIMetaDoc.Auth;
using APIMetaDoc.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;
using System.Net.Mail;

namespace APIMetaDoc.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var res = AuthService.Authenticate1(login.Username, login.Password);
                if (res != null)
                {
                    // Send email notification
                    SendLoginEmail(res.Username);

                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        private void SendLoginEmail(string userEmail)
        {
            try
            {
                // Load email template
                string emailTemplate = LoadEmailTemplate();

                // Replace placeholders with user-specific data
                string emailContent = emailTemplate.Replace("{{USER_EMAIL}}", userEmail);

                // Configure SMTP client
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("metadocofficials@gmail.com", "metadoc12");

                // Create email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("metadocofficials@gmail.com");
                mailMessage.To.Add(new MailAddress(userEmail));
                mailMessage.Subject = "Login Notification";
                mailMessage.Body = emailContent;
                mailMessage.IsBodyHtml = true;

                // Send email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors
                // You can customize the error handling as per your requirements
                Console.WriteLine("Failed to send login email: " + ex.Message);
            }
        }

        private string LoadEmailTemplate()
        {
            // Implement the logic to load the email template from a file or database
            // and return its content as a string
            // You can use libraries like RazorEngine or simply read the file contents
            // and replace placeholders with actual data
            string template = "<html><body><p>Welcome, {{USER_EMAIL}}!</p></body></html>";
            return template;
        }



    }
}
