using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using masterarepa.Models;
using System.Net.Mail;
using System.Net;

namespace masterarepa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendEmail(string name, string email, string subject, string message)
        {
            SmtpClient client = new SmtpClient("mail.masterarepa.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("site@masterarepa.com", "site123@");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(email);
            mailMessage.To.Add("info@masterarepa.com");
            mailMessage.Body = message;
            mailMessage.Subject = name + " sent a message from the web " + subject;
            client.Send(mailMessage);
            return RedirectToAction("");
        }
    }
}
