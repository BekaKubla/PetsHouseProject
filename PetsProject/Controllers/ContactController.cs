using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using PetsProject.ViewModels;

namespace PetsProject.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(contactViewModel.Email, "infomandzili@gmail.com"));
            message.To.Add(new MailboxAddress(contactViewModel.Subject, "infomandzili@gmail.com"));
            message.Subject = contactViewModel.Subject;
            message.Body = new TextPart("plain")
            {
                Text = contactViewModel.Subject + "\n" + "\n" + "ადრესატის სახელი : " + contactViewModel.ContactName + "\n" + "\n" + "ადრესატის ელ-ფოსტა" + contactViewModel.Email
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("infomandzili@gmail.com", "Kublashvili123!");
                client.Send(message);
                client.Disconnect(true);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
